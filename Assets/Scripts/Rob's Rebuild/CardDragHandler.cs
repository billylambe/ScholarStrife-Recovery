using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Handles dragging cards from the hand onto the board

// This script ONLY handles:
// - Dragging
// - Placement
// - Moving between parents

// This script does NOT handle gameplay

// We're using an Interface pattern as well as MonoBehaviour
public class CardDragHandler : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    private Transform originalParent;

    private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    private CardView cardView;

    private LayoutElement layoutElement;

    private GameObject placeholder;

    private LayoutElement placeholderLayout;

    private RectTransform handRect;

    private bool placeholderVisible;

    private void Awake()
    {
        // Cache component references
        rectTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();

        cardView = GetComponent<CardView>();

        canvas = GetComponentInParent<Canvas>();

        layoutElement = GetComponent<LayoutElement>();

    }

    // Called automatically when dragging starts
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store where the card came from
        originalParent = transform.parent;

        // Store the rect it came from for adding the placeholder
        handRect = originalParent.GetComponent<RectTransform>();

        // Create placeholder object
        placeholder = new GameObject("Card Placeholder");

        // Add LayoutElement so layout group treats it like a card
        placeholderLayout =
            placeholder.AddComponent<LayoutElement>();

        // Match placeholder size to this card
        LayoutElement thisLayout =
            GetComponent<LayoutElement>();

        placeholderLayout.preferredWidth =
            thisLayout.preferredWidth;

        placeholderLayout.preferredHeight =
            thisLayout.preferredHeight;

        // Put placeholder into original hand
        placeholder.transform.SetParent(originalParent);

        // Placeholder starts where card came from
        placeholder.transform.SetSiblingIndex(
            transform.GetSiblingIndex());

        // Disable layout control while dragging
        layoutElement.ignoreLayout = true;

        // Move to top canvas so it renders above everything
        transform.SetParent(canvas.transform);

        transform.SetAsLastSibling();

        // Disable raycast blocking while dragging
        canvasGroup.blocksRaycasts = false;
    }

    // Called continuously while dragging
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;

        // Check if mouse is inside the hand panel
        bool hoveringHand =
            RectTransformUtility.RectangleContainsScreenPoint(
                handRect,
                eventData.position,
                eventData.pressEventCamera);

        // Show placeholder only while hovering hand
        // Only change visibility if needed
        if (hoveringHand != placeholderVisible)
        {
            placeholderVisible = hoveringHand;

            placeholder.SetActive(placeholderVisible);
        }

        // Stop here if not hovering hand
        if (!hoveringHand)
        {
            return;
        }

        // Move placeholder through hand
        for (int i = 0; i < originalParent.childCount; i++)
        {
            Transform child = originalParent.GetChild(i);

            // Skip placeholder itself
            if (child == placeholder.transform)
            {
                continue;
            }

            RectTransform childRect =
    child.GetComponent<RectTransform>();

            // Get horizontal center of this card
            float childCenter =
                childRect.position.x;

            // Only move placeholder once mouse crosses center
            if (eventData.position.x < childCenter)
            {
                placeholder.transform.SetSiblingIndex(i);

                return;
            }
        }

        // Otherwise move to end
        placeholder.transform.SetAsLastSibling();
    }

    // Called automatically when dragging ends
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        GameObject hoveredObject = eventData.pointerEnter;

        // No valid target
        if (hoveredObject == null)
        {
            ReturnToHand();

            return;
        }


        // Check if hovering over the hand
        HandManager hand =
            hoveredObject.GetComponentInParent<HandManager>();

        if (hand != null)
        {
            // Return to hand panel
            transform.SetParent(originalParent);

            // Re-enable layout
            layoutElement.ignoreLayout = false;

            int newSiblingIndex = originalParent.childCount;

            // Check all cards currently in hand
            for (int i = 0; i < originalParent.childCount; i++)
            {
                Transform child = originalParent.GetChild(i);

                // Skip ourselves
                if (child == transform)
                {
                    continue;
                }

                // If mouse is left of this card,
                // insert before it
                if (eventData.position.x < child.position.x)
                {
                    newSiblingIndex = i;

                    // If we're moving forward in the hierarchy,
                    // offset index correctly
                    if (transform.GetSiblingIndex() < newSiblingIndex)
                    {
                        newSiblingIndex--;
                    }

                    break;
                }
            }

            // Move card into calculated position
            transform.SetSiblingIndex(newSiblingIndex);

            return;
        }


        // Check for a board slot
        BoardSlot slot = hoveredObject.GetComponentInParent<BoardSlot>();

        // Invalid placement target
        if (slot == null)
        {
            ReturnToHand();

            return;
        }

        // Prevent placement on occupied slots
        if (slot.occupied)
        {
            ReturnToHand();

            return;
        }

        // Check mana cost
        int manaCost = cardView.CurrentData.manaCost;

        if (!ManaManager.Instance.HasEnoughMana(manaCost))
        {
            ReturnToHand();

            return;
        }

        // Spend mana
        ManaManager.Instance.SpendMana(manaCost);

        // Mark slot occupied
        slot.occupied = true;

        // Move card onto board
        transform.SetParent(slot.transform, false);

        // Disable layout permanently once on board
        layoutElement.ignoreLayout = true;

        // Snap to center of slot
        rectTransform.localPosition = Vector3.zero;

        // Update tracking lists
        HandManager.Instance.RemoveCard(cardView);

        BoardManager.Instance.AddToBoard(cardView);

        Destroy(placeholder);

        // Disable dragging once played
        enabled = false;
    }

    // Return the card back to the hand
    private void ReturnToHand()
    {
        // Re-enable layout when returning to hand
        layoutElement.ignoreLayout = false;

        // Return to hand
        transform.SetParent(originalParent);

        placeholder.SetActive(true);

        // Snap into placeholder position
        transform.SetSiblingIndex(
            placeholder.transform.GetSiblingIndex());

        // Re-enable layout
        layoutElement.ignoreLayout = false;

        // Destroy placeholder
        Destroy(placeholder);
    }
}

// Hi Billy, notes on Interfaces if you havent used them before:

// Interfaces define a required set of functions a class must contain.
// By implementing "IBeginDragHandler"
// Unity now EXPECTS this function to exist:
// public void OnBeginDrag(PointerEventData eventData)

// That is how Unity’s UI EventSystem knows which functions
// to call automatically during dragging.

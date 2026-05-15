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

    private RectTransform handRect;

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

        // Store the hand panel rect
        handRect = originalParent.GetComponent<RectTransform>();

        // Disable layout control while dragging
        layoutElement.ignoreLayout = true;

        // Move to top canvas so it renders above everything
        transform.SetParent(canvas.transform);

        // Ensure dragged card renders above all others
        transform.SetAsLastSibling();

        // Disable raycast blocking while dragging
        canvasGroup.blocksRaycasts = false;
    }

    // Called continuously while dragging
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    // Called automatically when dragging ends
    public void OnEndDrag(PointerEventData eventData)
    {
        // Re-enable raycasts
        canvasGroup.blocksRaycasts = true;

        GameObject hoveredObject = eventData.pointerEnter;

        // No valid target
        if (hoveredObject == null)
        {
            ReturnToHand();

            return;
        }

        // Check for board slot first
        BoardSlot slot =
            hoveredObject.GetComponentInParent<BoardSlot>();

        // Successful board placement
        if (slot != null && !slot.occupied)
        {
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

            // Disable dragging once played
            enabled = false;

            return;
        }

        // Check if released over hand
        HandManager hand =
            hoveredObject.GetComponentInParent<HandManager>();

        if (hand != null)
        {
            ReorderInHand(eventData);

            return;
        }

        // Otherwise return to hand
        ReturnToHand();
    }

    // Reinsert the card into the hand
    private void ReorderInHand(PointerEventData eventData)
    {
        // Return card to hand
        transform.SetParent(originalParent);

        // Re-enable layout
        layoutElement.ignoreLayout = false;

        int targetIndex = originalParent.childCount;

        // Find insertion position
        for (int i = 0; i < originalParent.childCount; i++)
        {
            Transform child = originalParent.GetChild(i);

            // Skip ourselves
            if (child == transform)
            {
                continue;
            }

            // Insert before first card to the right
            if (eventData.position.x < child.position.x)
            {
                targetIndex = i;

                break;
            }
        }

        // Apply final sibling position
        transform.SetSiblingIndex(targetIndex);
    }

    // Return the card back to the hand
    private void ReturnToHand()
    {
        // Return to original hand parent
        transform.SetParent(originalParent);

        // Re-enable layout
        layoutElement.ignoreLayout = false;

        // Move to end of hand
        transform.SetAsLastSibling();
    }
}

// Hi Billy, notes on Interfaces if you havent used them before:

// Interfaces define a required set of functions a class must contain.
// By implementing "IBeginDragHandler"
// Unity now EXPECTS this function to exist:
// public void OnBeginDrag(PointerEventData eventData)

// That is how Unity’s UI EventSystem knows which functions
// to call automatically during dragging.


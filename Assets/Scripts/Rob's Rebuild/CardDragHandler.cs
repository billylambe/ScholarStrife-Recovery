using UnityEngine;
using UnityEngine.EventSystems;

// Handles dragging cards from the hand onto the board

// This script ONLY handles
// Dragging
// Placement
// Moving between parents

// This Script does NOT handle Gameplay

// We're using an Interface pattern as well as MonoBehaviour (see comment at end)
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

    private void Awake()
    {
        // Cache component references
        rectTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();

        cardView = GetComponent<CardView>();

        canvas = GetComponentInParent<Canvas>();
    }

    // Called automatically when dragging starts
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store where the card came from
        originalParent = transform.parent;

        // Move to top canvas so it renders above everything
        transform.SetParent(canvas.transform);

        // Disable raycast blocking while dragging
        canvasGroup.blocksRaycasts = false;
    }

    // Called continuously while dragging
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    // Called automatically when dragging ends
    // Called automatically when dragging ends
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        GameObject hoveredObject = eventData.pointerEnter;

        // Debug what object we released over
        if (hoveredObject != null)
        {
            Debug.Log("Released over: " + hoveredObject.name);
        }
        else
        {
            Debug.Log("Released over: NOTHING");
        }

        // No valid target
        if (hoveredObject == null)
        {
            Debug.Log("No hovered object found. Returning to hand.");

            ReturnToHand();

            return;
        }

        // Check for a board slot
        BoardSlot slot = hoveredObject.GetComponent<BoardSlot>();

        // No BoardSlot component found
        if (slot == null)
        {
            Debug.Log("Hovered object is NOT a BoardSlot.");

            ReturnToHand();

            return;
        }

        Debug.Log("Valid BoardSlot found.");

        // Prevent placement on occupied slots
        if (slot.occupied)
        {
            Debug.Log("Slot already occupied.");

            ReturnToHand();

            return;
        }

        // Check mana cost
        int manaCost = cardView.CurrentData.manaCost;

        Debug.Log("Card mana cost: " + manaCost);

        if (!ManaManager.Instance.HasEnoughMana(manaCost))
        {
            Debug.Log("Not enough mana.");

            ReturnToHand();

            return;
        }

        Debug.Log("Placement successful.");

        // Spend mana
        ManaManager.Instance.SpendMana(manaCost);

        // Mark slot occupied
        slot.occupied = true;

        // Move card onto board
        transform.SetParent(slot.transform);

        rectTransform.anchoredPosition = Vector2.zero;

        // Update tracking lists
        HandManager.Instance.RemoveCard(cardView);

        BoardManager.Instance.AddToBoard(cardView);

        // Disable dragging once played
        enabled = false;
    }

    // Return the card back to the hand
    private void ReturnToHand()
    {
        transform.SetParent(originalParent);

        rectTransform.anchoredPosition = Vector2.zero;
    }
}

// Hi Billy, notes in Interfaces if you havent used them before:

// Interfaces define a required set of functions a class must contain.
// By implementing "IBeginDragHandler"
// Unity now EXPECTS this function to exist:
// public void OnBeginDrag(PointerEventData eventData)
// That is how Unity’s UI EventSystem knows which functions to call automatically during dragging.
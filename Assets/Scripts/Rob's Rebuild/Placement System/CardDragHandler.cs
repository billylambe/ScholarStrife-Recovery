using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        rectTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();

        cardView = GetComponent<CardView>();

        canvas = GetComponentInParent<Canvas>();

        layoutElement = GetComponent<LayoutElement>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;

        handRect = originalParent.GetComponent<RectTransform>();

        layoutElement.ignoreLayout = true;

        transform.SetParent(canvas.transform);

        transform.SetAsLastSibling();

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        GameObject hoveredObject = eventData.pointerEnter;

        if (hoveredObject == null)
        {
            ReturnToHand();

            return;
        }

        BoardSlot slot =
            hoveredObject.GetComponentInParent<BoardSlot>();

        if (slot != null && !slot.occupied)
        {
            CardCombat combat = cardView.GetComponent<CardCombat>();

            int manaCost = cardView.CurrentData.manaCost;

            if (!ManaManager.Instance.HasEnoughMana(combat.owner, manaCost))
            {
                ReturnToHand();

                return;
            }

            ManaManager.Instance.SpendMana(combat.owner, manaCost);

            if (slot.owner != combat.owner)
            {
                ReturnToHand();

                return;
            }

            slot.occupied = true;

            slot.currentCard = cardView;

            combat.SetSlot(slot);

            combat.isOnBoard = true;

            combat.canAttack = true;

            transform.SetParent(slot.transform, false);

            layoutElement.ignoreLayout = true;

            rectTransform.localPosition = Vector3.zero;

            HandManager.Instance.RemoveCard(cardView);

            BoardManager.Instance.AddToBoard(cardView);

            enabled = false;

            return;
        }

        ReturnToHand();
    }

    private void ReturnToHand()
    {
        transform.SetParent(originalParent);

        layoutElement.ignoreLayout = false;

        transform.SetAsLastSibling();

        rectTransform.localPosition = Vector3.zero;
    }
}
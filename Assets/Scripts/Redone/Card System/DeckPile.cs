using UnityEngine;
using UnityEngine.EventSystems;

// Clickable deck pile that draws cards
public class DeckPile : MonoBehaviour, IPointerClickHandler
{
    [Header("Deck Owner")]
    public CardOwner owner;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Draw one card into the correct hand
        HandManager.Instance.DrawCardToHand(owner);
    }
}
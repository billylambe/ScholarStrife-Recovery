using UnityEngine;

// Attached to every board slot
public class BoardSlot : MonoBehaviour
{
    // Which side owns this slot
    public CardOwner owner;

    // Is a card currently occupying this slot
    public bool occupied = false;

    // The card currently in this slot
    public CardView currentCard;
}
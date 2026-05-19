using System.Collections.Generic;
using UnityEngine;
// Discard Pile (not visually rendered yet)
// When a card dies in battle (Player or Enemy) we will add it to a list
// "Used" cards (If you decide to make spell/effect cards) can also go into here


// Future systems could:
// - revive cards
// - reshuffle discard into deck
// - count creature deaths

public class DiscardManager : MonoBehaviour
{
    public static DiscardManager Instance;

    [Header("Runtime Discard Piles")]
    public List<CardData> playerDiscard =
        new List<CardData>();

    public List<CardData> enemyDiscard =
        new List<CardData>();

    private void Awake()
    {
        Instance = this;
    }

    // Add a card to the correct discard pile
    public void AddToDiscard(CardData cardData,CardOwner owner)
    {
        if (owner == CardOwner.Player)
        {
            playerDiscard.Add(cardData);
        }
        else
        {
            enemyDiscard.Add(cardData);
        }

        Debug.Log(cardData.cardName + " added to " + owner + " discard pile.");
    }
}
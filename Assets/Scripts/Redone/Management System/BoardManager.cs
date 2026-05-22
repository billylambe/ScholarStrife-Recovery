using System.Collections.Generic;
using UnityEngine;

// Manages what is in play on the board at run time
// Adds played cards to the board ONLY
public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;

    public List<CardView> cardsOnBoard = new List<CardView>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddToBoard(CardView card)
    {
        cardsOnBoard.Add(card);
    }

    // Checks if a side has cards on the board
    public bool HasCardsOnBoard(CardOwner owner)
    {
        foreach (CardView card in cardsOnBoard)
        {
            CardCombat combat =
                card.GetComponent<CardCombat>();

            if (combat.owner == owner)
            {
                return true;
            }
        }

        return false;
    }
}
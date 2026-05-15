using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        // Build the deck
        DeckManager.Instance.BuildDeck();

        // Shuffle the deck
        DeckManager.Instance.ShuffleDeck();

        // Draw opening hand
        DrawOpeningHand();
    }

    private void DrawOpeningHand()
    {
        for (int i = 0; i < HandManager.Instance.startingHandSize; i++)
        {
            CardData drawnCard =
                DeckManager.Instance.DrawCard();

            // Safety check
            if (drawnCard != null)
            {
                HandManager.Instance.DrawCardToHand(drawnCard);
            }
        }
    }
}
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
            CardData playerCard =
                DeckManager.Instance.DrawCard();

            HandManager.Instance.DrawCardToHand(
                playerCard,
                CardOwner.Player
            );

            CardData enemyCard =
                DeckManager.Instance.DrawCard();

            HandManager.Instance.DrawCardToHand(
                enemyCard,
                CardOwner.Enemy
            );
        }
    }
}
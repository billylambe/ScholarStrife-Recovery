using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

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

        // Draw opening hands
        DrawOpeningHands();
    }

    private void DrawOpeningHands()
    {
        HandManager.Instance.DrawCards(
            CardOwner.Player,
            HandManager.Instance.startingHandSize
        );

        HandManager.Instance.DrawCards(
            CardOwner.Enemy,
            HandManager.Instance.startingHandSize
        );
    }

    
}
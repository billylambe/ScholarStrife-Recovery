using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;

    [Header("Deck Settings")]
    public int deckSize = 60;

    [Header("Runtime Deck")]
    public List<CardData> currentDeck = new List<CardData>();

    private void Awake()
    {
        Instance = this;
    }

    // Build a random deck using cards from the database
    public void BuildDeck()
    {
        currentDeck.Clear();

        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = Random.Range(0, CardDatabase.Instance.allCards.Count);

            CardData randomCard =
                CardDatabase.Instance.allCards[randomIndex];

            currentDeck.Add(randomCard);
        }

        Debug.Log("Deck built with " + currentDeck.Count + " cards.");
    }

    // Shuffle the deck using Fisher-Yates (google it)
    public void ShuffleDeck()
    {
        for (int i = currentDeck.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            CardData temp = currentDeck[i];

            currentDeck[i] = currentDeck[randomIndex];

            currentDeck[randomIndex] = temp;
        }

        Debug.Log("Deck shuffled.");
    }

    // Draw the top card from the deck
    public CardData DrawCard()
    {
        // Prevent drawing from empty deck
        if (currentDeck.Count == 0)
        {
            Debug.Log("Deck is empty.");

            return null;
        }

        CardData drawnCard = currentDeck[0];

        currentDeck.RemoveAt(0);

        Debug.Log("Drew card: " + drawnCard.cardName);

        return drawnCard;
    }
}
using System.Collections.Generic;
using UnityEngine;

// Keeps track of the cards in your hand at runtime
// Allows cards to be added
// Allows cards to be taken away

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;

    [Header("Hand Settings")]
    public Transform handPanel;

    public GameObject cardPrefab;

    public int startingHandSize = 7; // Change this to better suit your game design

    [Header("Runtime Hand")]
    public List<CardView> cardsInHand = new List<CardView>();

    private void Awake()
    {
        Instance = this;
    }

    // Spawn a card into the hand
    public void DrawCardToHand(CardData cardData)
    {
        // Create the card prefab
        GameObject newCardObject =
            Instantiate(cardPrefab, handPanel);

        // Get the CardView component
        CardView newCard =
            newCardObject.GetComponent<CardView>();

        // Inject card data into the visuals
        newCard.Setup(cardData);

        // Track card in hand
        cardsInHand.Add(newCard);

        Debug.Log("Added " + cardData.cardName + " to hand.");
    }

    public void RemoveCard(CardView card)
    {
        cardsInHand.Remove(card);
    }
}
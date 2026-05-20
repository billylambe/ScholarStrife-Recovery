using System.Collections.Generic;
using UnityEngine;

// Keeps track of cards in both hands
public class HandManager : MonoBehaviour
{
    public static HandManager Instance;

    [Header("Player Hand")]
    public Transform playerHandPanel;
    public GameObject playerCardPrefab;

    [Header("Enemy Hand")]
    public Transform enemyHandPanel;
    public GameObject enemyCardPrefab;

    [Header("Hand Settings")]
    public int startingHandSize = 7;
    public int maxHandSize = 7;

    [Header("Runtime Hands")]
    public List<CardView> playerHand = new List<CardView>();
    public List<CardView> enemyHand = new List<CardView>();

    private void Awake()
    {
        Instance = this;
    }

    // Check if a hand has room for more cards
    public bool HasRoomInHand(CardOwner owner)
    {
        if (owner == CardOwner.Player)
        {
            return playerHand.Count < maxHandSize;
        }

        return enemyHand.Count < maxHandSize;
    }

    // Draw a card from the deck and spawn it into the correct hand
    public void DrawCardToHand(CardOwner owner)
    {
        // Prevent overfilling hand
        if (!HasRoomInHand(owner))
        {
            Debug.Log(owner + " hand is full.");

            return;
        }

        // Request card from deck
        CardData cardData = DeckManager.Instance.DrawCard();

        // Stop if deck is empty
        if (cardData == null)
        {
            return;
        }

        Transform targetHand;
        GameObject targetPrefab;
        List<CardView> targetList;

        // Decide which side to use
        if (owner == CardOwner.Player)
        {
            targetHand = playerHandPanel;
            targetPrefab = playerCardPrefab;
            targetList = playerHand;
        }
        else
        {
            targetHand = enemyHandPanel;
            targetPrefab = enemyCardPrefab;
            targetList = enemyHand;
        }

        // Spawn card prefab into correct hand
        GameObject newCardObject = Instantiate(targetPrefab, targetHand);

        // Get card view
        CardView newCard = newCardObject.GetComponent<CardView>();

        // Inject card data into visuals
        newCard.Setup(cardData);

        // Assign ownership
        CardCombat combat = newCardObject.GetComponent<CardCombat>();
        combat.owner = owner;

        // Track card in runtime hand
        targetList.Add(newCard);

        Debug.Log("Added " + cardData.cardName + " to " + owner + " hand.");
    }

    // Draw multiple cards
    public void DrawCards(CardOwner owner, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            DrawCardToHand(owner);
        }
    }

    // Remove card from correct runtime hand
    public void RemoveCard(CardView card)
    {
        CardCombat combat = card.GetComponent<CardCombat>();

        if (combat.owner == CardOwner.Player)
        {
            playerHand.Remove(card);
        }
        else
        {
            enemyHand.Remove(card);
        }
    }


}
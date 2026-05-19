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

    public int startingHandSize = 7;

    [Header("Runtime Hands")]
    public List<CardView> playerHand =
        new List<CardView>();

    public List<CardView> enemyHand =
        new List<CardView>();

    private void Awake()
    {
        Instance = this;
    }

    // Spawn a card into the correct hand
    public void DrawCardToHand(
        CardData cardData,
        CardOwner owner)
    {
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

        // Spawn prefab into correct hand
        GameObject newCardObject =
            Instantiate(targetPrefab, targetHand);

        // Get CardView
        CardView newCard =
            newCardObject.GetComponent<CardView>();

        // Inject card data
        newCard.Setup(cardData);

        // Assign ownership
        CardCombat combat =
            newCardObject.GetComponent<CardCombat>();

        combat.owner = owner;

        // Track in correct hand
        targetList.Add(newCard);

        Debug.Log(
            "Added " +
            cardData.cardName +
            " to " +
            owner +
            " hand."
        );
    }

    // Remove from correct runtime hand
    public void RemoveCard(CardView card)
    {
        CardCombat combat =
            card.GetComponent<CardCombat>();

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
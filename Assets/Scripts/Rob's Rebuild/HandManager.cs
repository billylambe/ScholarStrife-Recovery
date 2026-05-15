using System.Collections.Generic;
using UnityEngine;

// Keeps track of the cards in your hand at runtime
// Allows cards to be added
// Allows cards to be taken away

public class HandManager : MonoBehaviour
{
    public static HandManager Instance;

    public List<CardView> cardsInHand = new List<CardView>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddCard(CardView card)
    {
        cardsInHand.Add(card);
    }

    public void RemoveCard(CardView card)
    {
        cardsInHand.Remove(card);
    }
}
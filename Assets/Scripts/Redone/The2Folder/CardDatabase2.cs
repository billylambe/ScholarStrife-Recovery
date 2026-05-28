using System.Collections.Generic;
using UnityEngine;

// We're going to avoid Scriptable Objects because you said you didnt get on with them when you tried
// we are avoiding inspector-generated card definitions (too much to guess at when debugging)
// We're going to avoid inherritance

// for now, we just want:
// Predictable runtime behaviour
// Easy debugging
// Easy breakpoints
// No hidden asset dependecies

public class CardDatabase2 : MonoBehaviour
{
    public static CardDatabase2 Instance;

    public List<CardData> allCards2 = new List<CardData>();

    private void Awake()
    {
        Instance = this;

        BuildDatabase2();
    }

    private void BuildDatabase2()
    {
        // I used ChatGPT to make some random card values so make sure you replace these
        CreateCard("test", 1, 2, 1, "A weak aggressive creature.");
        CreateCard("test", 3, 4, 5, "A durable frontline fighter.");
        CreateCard("test", 2, 3, 2, "Fast and relentless.");
        CreateCard("test", 2, 2, 3, "Attacks safely from range.");
        CreateCard("test", 5, 6, 8, "Heavy defensive unit.");
        CreateCard("test", 4, 5, 3, "Master of arcane power.");
        CreateCard("test", 1, 1, 2, "Cheap early pressure.");
        CreateCard("test", 4, 4, 6, "Balanced holy warrior.");
        CreateCard("test", 8, 10, 10, "Massive late-game threat.");
        CreateCard("test", 1, 1, 3, "Weak but durable.");
        CreateCard("test", 3, 5, 2, "High damage glass cannon.");
        CreateCard("test", 2, 1, 4, "Support focused unit.");
        CreateCard("test", 1, 2, 1, "Fragile undead servant.");
        CreateCard("test", 5, 7, 4, "Dark magic specialist.");
        CreateCard("test", 2, 2, 5, "Reliable defender.");
        CreateCard("test", 4, 7, 3, "Extremely aggressive.");
        CreateCard("test", 3, 3, 4, "Nature attuned fighter.");
        CreateCard("test", 6, 7, 5, "Rare mythical creature.");
        CreateCard("test", 2, 3, 2, "Quick attacking rogue.");
        CreateCard("test", 7, 8, 8, "Leader of the battlefield.");
    }

    private void CreateCard(
        string name,
        int mana,
        int attack,
        int health,
        string description)
    {
        CardData newCard = new CardData();

        newCard.cardName = name;
        newCard.manaCost = mana;
        newCard.attack = attack;
        newCard.health = health;
        newCard.description = description;

        allCards2.Add(newCard);
    }
}
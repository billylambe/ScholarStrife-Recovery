using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// We're going to avoid Scriptable Objects because you said you didnt get on with them when you tried
// we are avoiding inspector-generated card definitions (too much to guess at when debugging)
// We're going to avoid inherritance

// for now, we just want:
// Predictable runtime behaviour
// Easy debugging
// Easy breakpoints
// No hidden asset dependecies

public class CardDatabase : MonoBehaviour
{
    public static CardDatabase Instance;
    public string deck1Scene;
    public string deck2Scene;

    public List<CardData> allCards = new List<CardData>();

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "GameDeck1")
        {
            Instance = this;

            BuildDatabase();
        }

        if (scene.name == "Deck1Incremental")
        {
            Instance = this;

            BuildDatabase();
        }
        //Instance = this;

        //BuildDatabase();

        if (scene.name == "GameDeck2")
        {
            Instance = this;

            BuildDatabase2();
        }
    }

    private void BuildDatabase()
    {
        // I used ChatGPT to make some random card values so make sure you replace these
        CreateCard("Goblin", 1, 2, 1, "A weak aggressive creature.");
        CreateCard("Knight", 3, 4, 5, "A durable frontline fighter.");
        CreateCard("Wolf", 2, 3, 2, "Fast and relentless.");
        CreateCard("Archer", 2, 2, 3, "Attacks safely from range.");
        CreateCard("Golem", 5, 6, 8, "Heavy defensive unit.");
        CreateCard("Mage", 4, 5, 3, "Master of arcane power.");
        CreateCard("Bandit", 1, 1, 2, "Cheap early pressure.");
        CreateCard("Paladin", 4, 4, 6, "Balanced holy warrior.");
        CreateCard("Dragon", 8, 10, 10, "Massive late-game threat.");
        CreateCard("Slime", 1, 1, 3, "Weak but durable.");
        CreateCard("Assassin", 3, 5, 2, "High damage glass cannon.");
        CreateCard("Priest", 2, 1, 4, "Support focused unit.");
        CreateCard("Skeleton", 1, 2, 1, "Fragile undead servant.");
        CreateCard("Warlock", 5, 7, 4, "Dark magic specialist.");
        CreateCard("Guard", 2, 2, 5, "Reliable defender.");
        CreateCard("Berserker", 4, 7, 3, "Extremely aggressive.");
        CreateCard("Druid", 3, 3, 4, "Nature attuned fighter.");
        CreateCard("Phoenix", 6, 7, 5, "Rare mythical creature.");
        CreateCard("Pirate", 2, 3, 2, "Quick attacking rogue.");
        CreateCard("King", 7, 8, 8, "Leader of the battlefield.");
    }

    private void BuildDatabase2()
    {
        // I used ChatGPT to make some random card values so make sure you replace these
        CreateCard("test", 1, 2, 1, "A weak aggressive creature.");
        CreateCard("test", 3, 4, 5, "A durable frontline fighter.");
        CreateCard("Wtest", 2, 3, 2, "Fast and relentless.");
        CreateCard("test", 2, 2, 3, "Attacks safely from range.");
        CreateCard("test", 5, 6, 8, "Heavy defensive unit.");
        CreateCard("test", 4, 5, 3, "Master of arcane power.");
        CreateCard("test", 1, 1, 2, "Cheap early pressure.");
        CreateCard("testn", 4, 4, 6, "Balanced holy warrior.");
        CreateCard("test", 8, 10, 10, "Massive late-game threat.");
        CreateCard("test", 1, 1, 3, "Weak but durable.");
        CreateCard("test", 3, 5, 2, "High damage glass cannon.");
        CreateCard("test", 2, 1, 4, "Support focused unit.");
        CreateCard("test", 1, 2, 1, "Fragile undead servant.");
        CreateCard("test", 5, 7, 4, "Dark magic specialist.");
        CreateCard("test", 2, 2, 5, "Reliable defender.");
        CreateCard("testr", 4, 7, 3, "Extremely aggressive.");
        CreateCard("test", 3, 3, 4, "Nature attuned fighter.");
        CreateCard("Phoenix", 6, 7, 5, "Rare mythical creature.");
        CreateCard("Pirate", 2, 3, 2, "Quick attacking rogue.");
        CreateCard("King", 7, 8, 8, "Leader of the battlefield.");

        CreateCard("Echo Master", 6, 3, 4, "Teller of great stories."); //tom's custom card as a prize for winning on first try
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

        allCards.Add(newCard);
    }
}
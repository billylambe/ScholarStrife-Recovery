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


public class CardDatabase : MonoBehaviour
{
    public static CardDatabase Instance; // A singular instance of the database

    public List<CardData> allCards = new List<CardData>(); // The public list of cards

    private void Awake() // On awake we initiaize the database
    {
        Instance = this;

        BuildDatabase();
    }

    private void BuildDatabase() // Builds the database using the card data below (you'll add more later)
    {
        CardData goblin = new CardData();

        goblin.cardName = "Goblin";
        goblin.manaCost = 1;
        goblin.attack = 2;
        goblin.health = 1;
        goblin.description = "A weak but aggressive creature.";

        allCards.Add(goblin);



        CardData knight = new CardData();

        knight.cardName = "Knight";
        knight.manaCost = 3;
        knight.attack = 4;
        knight.health = 5;
        knight.description = "A durable frontline fighter.";

        allCards.Add(knight);
    }
}
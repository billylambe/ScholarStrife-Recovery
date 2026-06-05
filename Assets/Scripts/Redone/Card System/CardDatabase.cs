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

        
        if (scene.name == "GameDeck1Incremental")
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

        if (scene.name == "GameDeckCrazy")
        {
            Instance = this;

            BuildDatabase3();
        }
    }

    private void BuildDatabase()
    {

        CreateCard("Bat", 1, 1, 2, "A weak and lone bat");
        CreateCard("Zombie", 2, 1, 2, "A directionless corpse let loose");
        CreateCard("Skeleton", 2, 2, 1, "Reanimated bones driven by vengence");
        CreateCard("Vampire", 4, 2, 3, "A lord of the forgotten nights");
        CreateCard("Bat", 1, 1, 1, "A weak and lone bat");
        CreateCard("Zombie", 2, 1, 2, "A directionless corpse let loose");
        CreateCard("Skeleton", 2, 2, 1, "Reanimated bones driven by vengence");
        CreateCard("Swarm of bats", 3, 3, 2, "A swarm of feral beasts");
        CreateCard("Flesh beast", 0, 0, 1, "A blob of discarded flesh");
        CreateCard("Wight", 3, 3, 3, "A champion of the undead");
        CreateCard("Ghost", 2, 3, 1, "A frail appiration");
        CreateCard("Swarm of bats", 3, 3, 2, "A swarm of feral beasts");
        CreateCard("Flesh beast", 0, 0, 1, "A blob of discarded flesh");
        CreateCard("Wight", 3, 3, 3, "A champion of the undead");
        CreateCard("Ghost", 2, 3, 1, "A frail appiration");
        CreateCard("Wisp", 0, 1, 1, "A forgotten soul");
        CreateCard("Wisp", 0, 1, 1, "A forgotten soul");
        CreateCard("Lich", 5, 3, 4, "The horde's saviour");
        
    }

    private void BuildDatabase2()
    {

        CreateCard("Clay golem", 5, 3, 4, "A mindless but friendly golem made from clay ");
        CreateCard("Iron golem", 6, 4, 5, "A mindless but aggressive golem made from Iron");
        CreateCard("Titan's Herald", 2, 1, 2, "Often considered a omen of ruin"); //want to add affect of boosting other cards
        CreateCard("The Primordial", 12, 13, 13, "The prime mover of life and father of all Titans");
        CreateCard("Mineral golem", 5, 3, 5, "A golem born from a geode");
        CreateCard("Dawn beast", 6, 5, 4, "A large beast that hunts at dawn");
        CreateCard("Ruin golem", 5, 6, 3, "A shattered husk that still protects");
        CreateCard("Mechanical golem", 4, 4, 6, "A pale attempt to imitate golems");
        CreateCard("Clay golem", 5, 3, 4, "A mindless but friendly golem made from clay ");
        CreateCard("Iron golem", 6, 4, 5, "A mindless but aggressive golem made from Iron");
        CreateCard("Titan's Herald", 2, 1, 2, "Often considered a omen of ruin"); //want to add affect of boosting other cards
        CreateCard("Borun - Void titan", 11, 11, 8, "The titan who holds life from the abyss");
        CreateCard("Imix - Fire titan", 7, 8, 6, "The titan shaper of flames");
        CreateCard("Ogru - Earth titan", 8, 6, 10, "The titan who shaped the continents");
        CreateCard("Aatsu - Sky titan", 8, 7, 9, "The titan who holds the sky");
        CreateCard("Eiros - Water titan", 7, 5, 9, "The titan who carved the seas");
        CreateCard("Uva - World titan", 9, 8, 10, "The one who brought life");
        CreateCard("Uvon - Celestial titan", 10, 11, 9, "The one who moves the stars");
    }


    private void BuildDatabase3()
    {

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
        CreateCard("Echo Master", 6, 3, 4, "Teller of great stories."); //tom's custom card as a prize for winning on first try and having an 100% winstreak across all his 5 games
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
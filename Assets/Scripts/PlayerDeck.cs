using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class PlayerDeck : MonoBehaviour
{
    //differs between the deck, the deck databse and then the holder
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    //deck maths
    public int x;
    static public int deckSize;

    //for dynamically showing how few cards or many cards are in the deck
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    //for knowing what state the cards are (card back to prevent from seeing next card draw) and to distinguish between the clones and cards in hand
    public GameObject CardToHand;
    public GameObject CardBack;
    public GameObject Deck;
    public GameObject[] Hand;
    public GameObject[] Clones;
    

    void Start()
    {
        //shuffle deck from the cards in the database
        x = 0;
        deckSize = 15;
        for (int i = 0; i < deckSize; i++)
        {
            x = Random.Range(1, 4);
            deck[i] = CardDataBase.cardList[x];
        }

        StartCoroutine(StartGame());
    }

    //dynamically display how  many or few cards left in deck
    void Update()
    {
        staticDeck = deck;
        if(deckSize < 12)
        {
            cardInDeck4.SetActive(false);
        }
        if (deckSize < 9)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize < 6)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize == 0)
        {
            cardInDeck1.SetActive(false);
        }
        if (TurnSystem.startTurn == true)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startTurn = false;

        }
    }

    //prevents duplication or card overflow
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach(GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }

   //placing the card inn hand 
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i <= 4; i++)
        {
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
        
        
    }


    //shuffle the deck 
    public void Shuffle()
    {
        for(int i = 0;i < deckSize;i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(1, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(Example());
    }

    //draw x amount of cards (can be used to create cards that allow for card draw)
    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
        
    }
}

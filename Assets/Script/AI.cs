using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AI : MonoBehaviour
{
   
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticEnemyDeck = new List<Card>();

    public List<Card> cardsInHand = new List<Card>();

    // CAN BE DELETED      CAN BE DELETED     CAN BE DELETED
    //public bool AICanPlay;


    //world space variables
    public GameObject Hand;
    public GameObject Zone;

    //Card variables
    public int x;
    public static int deckSize;
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;
    public GameObject CardToHand;
    public GameObject CardBack;

    public GameObject[] Clones;
    public static bool draw;

    // variables for playing cards
    public int currentMana;
    public bool[] AICanPlay;
    public bool drawPhase;
    public bool playPhase;
    public bool attackPhase;
    public bool endphase;
    public int[] cardsID;
    public int summonThisId;
    public AICardToHand AICardToHand;
    public int summonID;
    public int howManyCards;

    //assigning the data to cards
    void Start()
    {
        StartCoroutine(WaitForFiveSeconds());
        
        StartCoroutine(StartGame());
        Hand = GameObject.Find("HandPanel-Opponent");
        Zone = GameObject.Find("CardZone-Opponent");
        x = 0;
        deckSize = 15;
        draw = true;
        for(int i = 0; i<deckSize; i++)
        {
            x = Random.Range(1, 4);
            deck[i] = CardDataBase.cardList[x];
        }
    }

    //visually referencing deck size
    void Update()
    {
        if (deckSize < 12)
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

        currentMana = TurnSystem.currentEnemyMana;


        //the ai's ability to play cards or play the game
        if(0 == 0)
        {
            int j = 0;
            howManyCards = 0;
            foreach(Transform child in Hand.transform)
            {
                howManyCards++;
            }

            foreach(Transform child in Hand.transform)
            {
                cardsInHand[j] = child.GetComponent<AICardToHand>().thisCard[0];
                j++;
            }

            for(int i = 0; i < 15; i++)
            {
                if(i >= howManyCards)
                {
                    cardsInHand[i] = CardDataBase.cardList[0];
                }
            }
            j = 0;
        }
        if (TurnSystem.isYourTurn == false)
        {
            for (int i = 0; i < 15; i++)
            {
                if (cardsInHand[i].id != 0)
                {
                    if (currentMana >= cardsInHand[i].cost)
                    {
                        AICanPlay[i] = true;
                    }
                }
            }
        }

        else
        {
            for(int i = 0; i < 15; i++)
            {
                AICanPlay[i] = false;
            }
        }

        if (TurnSystem.isYourTurn == false)
        {
            drawPhase = true;
        }

        if(drawPhase == true && playPhase == false && attackPhase == false)
        {
            StartCoroutine(WaitForPlayPhase());

        }

        if(TurnSystem.isYourTurn == true)
        {
            drawPhase = false;
            playPhase = false;
            attackPhase = false;
            endphase = false;
        }

        if (playPhase == true)
        {
            summonID = 0;
            summonID = 0;

            int index = 0;
            for(int i = 0; i < 15; i++)
            {
                if (AICanPlay[i] == true)
                {
                    cardsID[index] = cardsInHand[i].id;
                    index++;
                }
            }

            for(int i = 0; i < 15; i++)
            {
                if (cardsID[i] != 0)
                {
                    if (cardsID[i] > summonID)
                    {
                        summonID = cardsID[i];
                    }
                }
            }

            summonThisId = summonID;

            foreach(Transform child in Hand.transform)
            {
                if(child.GetComponent<AICardToHand>().id == summonThisId && CardDataBase.cardList[summonThisId].cost <= currentMana)
                {
                    child.transform.SetParent(Zone.transform);
                    TurnSystem.currentEnemyMana -= CardDataBase.cardList[summonID].cost;
                    break;
                }
            }

            playPhase = false;
            attackPhase = true;
        }
        // CAN BE DELETED      CAN BE DELETED     CAN BE DELETED
        // if(AICanPlay == true)
        // {
        //     for(int i = 0; i < 15; i++)
        //     {
        //         if (AICardToHand.cardsInHandStatic[i].id !=0)
        //         {
        //             cardsInHand[i] = AICardToHand.cardsInHandStatic[i];
        //         }
        //     }
        // }
    }

    //shuffle the deck
    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(1, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(Example());
    }


    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }
    
    //upon starting game
       IEnumerator StartGame()
       {
           yield return new WaitForSeconds(1);
           for (int i = 0; i <= 4; i++)
           Instantiate(CardToHand, transform.position, transform.rotation);
         
        }

    //when the opponent draw a card for turn or plays card that allows multiple card draw
    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }

    }

    //pretend to think while playing cards
    IEnumerator WaitForFiveSeconds()
    {
        yield return new WaitForSeconds(5);
        //AICanPlay = true; 
    }

    //wait to play
    IEnumerator WaitForPlayPhase()
    {
        yield return new WaitForSeconds(5);
        playPhase = true;
    }
}

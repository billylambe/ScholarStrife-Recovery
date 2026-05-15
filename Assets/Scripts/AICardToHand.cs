using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.XR;
using JetBrains.Annotations;

public class AICardToHand : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();

    // CAN BE DELETED      CAN BE DELETED     CAN BE DELETED
    //public static List<Card> cardsInHandStatic = new List<Card>();
    //public List<Card> cardsInHand = new List<Card>();
    //public static int cardsInHandNumber;

    // card variables needed
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int damage;
    public string cardDescription;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    //this exists here solely for the player damaging the opponent and needs to be added to the other script for the player to be hurt
    public int damaged;

    //hand and deck
    public GameObject Hand;
    public int z = 0;
    public GameObject It;
    public int numberOfCardsInDeck;

    //can the enemy cards be killed
    public bool isTarget;
    public bool thisCardCanBeDestroyed;
    public GameObject Graveyard;

    void Start()
    {
        // CAN BE DELETED      CAN BE DELETED     CAN BE DELETED
        //cardsInHandStatic = cardsInHand;

        //basically choosing and shuffling the deck as well as confirm where the hand and graveyard is
        thisCard[0] = CardDataBase.cardList[thisId];
        Hand = GameObject.Find("HandPanel-Opponent");
        z = 0;
        numberOfCardsInDeck = AI.deckSize;

        Graveyard = GameObject.Find("EnemyGraveyard");
        StartCoroutine(AfterVoidStart());
    }

    void Update()
    {
        if (z == 0)
        {
            It.transform.SetParent(Hand.transform);
            It.transform.localScale = Vector3.one;
            It.transform.position = new Vector3(transform.position.x, transform.position.y - 48);
            It.transform.eulerAngles = new Vector3(25, 0, 0);
            z = 1;
        }

        //confirming and displaying card details
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        damage = thisCard[0].damage;
        cardDescription = thisCard[0].cardDescription;

        thisSprite = thisCard[0].thisImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + damage;
        descriptionText.text = "" + cardDescription;

        thatImage.sprite = thisSprite;

        //after playing a card remove it from the 'deck' not the deck database
        if (this.tag == "Clone")
        {
            // CAN BE DELETED      CAN BE DELETED     CAN BE DELETED
            //cardsInHand[cardsInHandNumber] = AI.staticEnemyDeck[numberOfCardsInDeck-1];
            //cardsInHandNumber++;

            thisCard[0] = AI.staticEnemyDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            AI.deckSize -= 1;
            this.tag = "Untagged";
        }

        
        //can you kill the card and what happens
        if (damaged >= damage && thisCardCanBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            damaged = 0;
        }    
         
        // CAN BE DELETED      CAN BE DELETED     CAN BE DELETED
        //for(int i = 0; i < 15; i++)
        //{
        //    if (cardsInHand[i].id !=0)
        //    {
        //        cardsInHandStatic[i] = cardsInHand[i];
        //    }
        //}
    }


    public void BeingTarget()
    {
        isTarget = true;
    }

    public void DontBeingTarget()
    {
        isTarget = false;
    }

    //short delay for kill
    IEnumerator AfterVoidStart()
    {
        yield return new WaitForSeconds(1);
        thisCardCanBeDestroyed = true;
    }
}

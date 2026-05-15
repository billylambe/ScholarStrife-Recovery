using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    
    //card variables
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

    //bool for showing back of card
    public bool cardBack;
    public static bool staticCardBack;

   // deck size and hand placement
    public GameObject Hand;
    public int numberOfCardsInDeck;

    //can a card be placed in the battle zone and state manager for it
    public bool canBePlayed;
    public bool played;
    public GameObject battleZone;

    //can a card attack(shown with border) and their target and other variables to ensure combat is fair
    public GameObject attackBorder;
    public GameObject Target;
    public GameObject Enemy;
    public bool summoningSickness;
    public bool cantAttack;
    public bool canAttack;
    public static bool staticTargeting;
    public static bool staticTargetingEnemy;
    public bool targeting;
    public bool targetingEnemy;
    public bool onlyThisCardAttack;

    //enemy detsils
    public GameObject EnemyZone;
    public AICardToHand aiCardToHand;


    //reevaluate
    public int damaged;

    
    //attacking or natural state upon instantiating cards
    void Start()
    {
        thisCard [0] = CardDataBase.cardList[thisId];
       // numberOfCardsInDeck = PlayerDeck.deckSize;

        canBePlayed = false;
        played = false;

        canAttack = false;
        summoningSickness = true;
        Enemy = GameObject.Find("Enemy HP");
        targeting = false;
        targetingEnemy = false;

        EnemyZone = GameObject.Find("CardZone-Opponent");
    }
    
    
    //card details of where to spawn and the cards variables and display
    //void Update()
    //{
    //    Hand = GameObject.Find("HandPanel-Player");
    //    if(this.transform.parent == Hand.transform.parent)
    //    {
    //        cardBack = false;
    //    }

    //    id = thisCard[1].id;
    //    cardName = thisCard[1].cardName;
    //    cost = thisCard[1].cost;
    //    damage = thisCard[1].damage;
    //    cardDescription = thisCard[1].cardDescription;

    //    thisSprite = thisCard[1].thisImage; 

    //    nameText.text = "" + cardName;
    //    costText.text = "" + cost;
    //    powerText.text = "" + damage;
    //    descriptionText.text = "" + cardDescription;

    //    thatImage.sprite = thisSprite;

    //    staticCardBack = cardBack;

    //    //remove a played card from deck so it cant be replayed
    //    if(this.tag == "Clone")
    //    {
    //        thisCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
    //        numberOfCardsInDeck -= 1;
    //    //    PlayerDeck.deckSize -= 1;
    //        cardBack = false;
    //        this.tag = "Untagged";
    //    }

    //    //can you play cards
    //    if(TurnSystem.currentMana >= cost && played == false)
    //    {
    //        canBePlayed = true;
    //    }
    //    else
    //    {
    //        canBePlayed = false;
    //    }
        
    //    //if or if not card can be dragged to prevent unplayable cards from being used
    //    if(canBePlayed == true)
    //    {
    //        gameObject.GetComponent<Draggable>().enabled = true;

    //    }
    //    else
    //    {
    //        gameObject.GetComponent<Draggable>().enabled = false;
    //    }
        
    //    //put cards in battlezone
    //    battleZone = GameObject.Find("CardZone-Player");
    //    if(played == false && this.transform.parent == battleZone.transform)
    //    {
    //        PlayCard();
    //    }

    //    if(canAttack == true)
    //    {
    //        attackBorder.SetActive(true);
    //    }
    //    else
    //    {
    //        attackBorder.SetActive(false);
    //    }

    //    //if after being played the next turn it can be used to attack
    //    if (TurnSystem.isYourTurn == false && played == true)
    //    {
    //        summoningSickness = false;
    //        cantAttack = false;
    //    }

    //    //checks for attacking
    //    if (TurnSystem.isYourTurn == true && summoningSickness == false && cantAttack == false)
    //    {
    //        canAttack = true;
    //    }
    //    else
    //    {
    //        canAttack = false;
    //    }

    //    //enemy details anfd target details or if you are targeting someone
    //    targeting = staticTargeting;
    //    targetingEnemy = staticTargetingEnemy;             

    //    if (targetingEnemy == true)
    //    {
    //        Target = Enemy;
    //    }
    //    else
    //    {
    //        Target = null;
    //    }

    //    //attack on valid target
    //    if(targeting == true && targetingEnemy == true && onlyThisCardAttack == true)
    //    {
    //        Attack();
    //    }
    //}

    //subtract played card cost from mana
    public void PlayCard()
    {
        TurnSystem.currentMana -= cost;
        played = true;
    }

    //attack details
    public void Attack()
    {
        if(canAttack == true)
        {
            if(Target != null)
            {
                if(Target == Enemy)
                {
                    EnemyHP.staticHp -= damage;
                    targeting = false;
                    cantAttack = true;
                }

              //  if (Target.name == "CardToHand(Clone)")
              //  {
              //      canAttack = true;
              //  }
            }

            else
            {
                foreach(Transform child in EnemyZone.transform)
                {
                    if(child.GetComponent<AICardToHand>().isTarget == true)
                    {
                        child.GetComponent<AICardToHand>().damaged = damage;
                        damaged = child.GetComponent<AICardToHand>().damage;
                        cantAttack = true;
                    }
                }
            }
        }
    }

    public void UntargetEnemy()
    {
        staticTargetingEnemy = false;
    }
    public void TargetEnemy()
    {
        staticTargetingEnemy = true;
    }
    public void StartAttack()
    {
        staticTargeting = true;
    }
    public void StopAttack()
    {
        staticTargeting = false;
    }
    public void OneCardAttack()
    {
        onlyThisCardAttack = true;
    }
    public void OneCardAttackStop()
    {
        onlyThisCardAttack = false;
    }
}

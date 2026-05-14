using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    //whos turn is it
    public static bool isYourTurn;
    public int yourTurn;
    public int yourOpponentTurn;
    public Text turnText;

    //resource tracking and display for player
    public static int maxMana;
    public static int currentMana;
    public Text ResourceText;
    public static bool startTurn;

   // Resource tracking and display for enemy
    public static int maxEnemyMana;
    public static int currentEnemyMana;
    public Text EnemyResourceText;


    //upkeep or start of game
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        yourOpponentTurn = 0;
        maxMana = 1;
        currentMana = 1;
        startTurn = false;

        maxEnemyMana = 0;
        currentEnemyMana = 0;
    }

   //display the details of curfrent turn and details for resources
    void Update()
    {
        if (isYourTurn == true)
        {
            turnText.text = "Your Turn";

        }
        else
        {
            turnText.text = "Opoonents turn";
        }
        ResourceText.text = currentMana + "/" + maxMana;
        EnemyResourceText.text = currentEnemyMana + "/" + maxEnemyMana;
    }

    //after ending turn enemy gains resources to play and sets starting resources
    public void EndYourTurn()
    {
        isYourTurn = false;
        yourOpponentTurn += 1;

        maxEnemyMana += 1;
        //currentEnemyMana += 1;
        currentEnemyMana = maxEnemyMana;

    }

    //when your turn beguins afain
    public void EndYourOpponentTurn()
    {
        isYourTurn = true;
        yourTurn += 1;
        maxMana += 1;
        currentMana = maxMana;
        startTurn = true;
    }
}

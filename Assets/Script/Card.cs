using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    //card template
    public int id;
    public string cardName;
    public int cost;
    public int damage;
    public string cardDescription;
    public Sprite thisImage;


    public Card()
    {

    }

    //confirm details to appropriate place
    public Card(int Id, string CardName, int Cost, int Damage, string CardDescription, Sprite ThisImage)
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        damage = Damage;
        cardDescription = CardDescription;

        thisImage = ThisImage;
    }
    
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();


    //card database catagorised in ID, Name, life, damage, description, card image
    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "Nothing, an empty card", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(1, "Bat", 1, 1, "a bat", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(2, "Zombie", 2, 1, "a zombie", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(3, "Skeleton", 2, 2, "a skeleton", Resources.Load<Sprite>("1")));
        cardList.Add(new Card(4, "Vampire", 3, 3, "a vampire", Resources.Load<Sprite>("1")));
    }
}
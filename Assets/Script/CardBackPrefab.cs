using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardBackPrefab : MonoBehaviour
{
    //variables and showing that the cards still in deck 
    public GameObject Deck;
    public GameObject It;

    //if still in deck show back
    void Update()
    {
        Deck = GameObject.Find("DeckPanel");
        It.transform.SetParent(Deck.transform);
        It.transform.localScale = Vector3.one;
        It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        It.transform.eulerAngles = new Vector3(25, 0, 0);
    }

}

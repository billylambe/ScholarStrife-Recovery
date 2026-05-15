using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardBack : MonoBehaviour
{
    public GameObject cardBack;

    //is the card showing a back
    void update()
    {
        if(ThisCard.staticCardBack == true)
        {
            cardBack.SetActive(true);
        }
        else
        {
            cardBack.SetActive(false);
        }
    }
}

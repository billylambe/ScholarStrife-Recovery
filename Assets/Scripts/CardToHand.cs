using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardToHand : MonoBehaviour
{
    //hand variables
    public GameObject Hand;
    public GameObject It;

    //confrim player hand location
    void Update()
    {
        Hand = GameObject.Find("HandPanel-Player");
        It.transform.SetParent(Hand.transform);
        It.transform.localScale = Vector3.one;
        It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        It.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}

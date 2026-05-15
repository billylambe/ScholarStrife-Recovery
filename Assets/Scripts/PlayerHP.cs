using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHP : MonoBehaviour
{
    //HP Variables
    public static float maxHp;
    public static float staticHp;
    public float hp;
    public Text hpText;
    
    
    // hp at start
    void Start()
    {
        maxHp = 20;
        staticHp = 10;
    }

    // dispaly hp
    void Update()
    {
        hp = staticHp;
        if (hp >= maxHp)
        {
            hp = maxHp;
        }

        hpText.text = hp + "";
    }
}

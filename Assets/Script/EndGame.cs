using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    //text variables
    public Text victoryText;
    public GameObject textObject;
    
    // dont show until needed
    void Start()
    {
        textObject.SetActive(false);
    }

    // shows result after someything happened
    void Update()
    {
        if(PlayerHP.staticHp <= 0)
        {
            textObject.SetActive(true);
            victoryText.text = "Defeat";
        }

        if (EnemyHP.staticHp <= 0)
        {
            textObject.SetActive(true);
            victoryText.text = "Defeat";
        }

        if (EnemyHP.staticHp <= 0 && PlayerHP.staticHp <= 0)
        {
            textObject.SetActive(true);
            victoryText.text = "Draw";
        }
    }
}

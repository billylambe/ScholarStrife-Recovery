using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    public GameObject textObject;
    public GameObject playAgain;
    public Text victoryText;
    public int playerCheck;
    public int enemyCheck;

    void Start()
    {
        textObject.SetActive(false);
        playAgain.SetActive(false);
    }

    private void FixedUpdate()
    {
        playerCheck = GameObject.Find("PlayerHeroCard").GetComponent<HeroCard>().currentHealth;
        enemyCheck = GameObject.Find("EnemyHeroCard").GetComponent<EnemyHeroCard>().enemycurrentHealth;
    }

    private void Update()
    {
        if (playerCheck <= 0 && enemyCheck > 0)
        {
            textObject.SetActive(true);
            playAgain.SetActive(true);
            victoryText.text = "Defeat";
        }

        if (enemyCheck <= 0 && playerCheck > 0)
        {
            textObject.SetActive(true);
            playAgain.SetActive(true);
            victoryText.text = "Victory";
        }

        if (playerCheck <= 0 && enemyCheck <=0)
        {
            textObject.SetActive(true);
            playAgain.SetActive(true);
            victoryText.text = "Draw";
        }

    }
}

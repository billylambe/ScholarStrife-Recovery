using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    public GameObject textObject;
    public GameObject playAgain;
    public GameObject mainMenu;
    public Text victoryText;
    public float playerCheck;
    public float enemyCheck;

    void Start()
    {
        textObject.SetActive(false);
        playAgain.SetActive(false);
        mainMenu.SetActive(false);
    }

    private void FixedUpdate()
    {
        playerCheck = 20;
        enemyCheck = 20;
    }

    private void Update()
    {
        playerCheck = GameObject.Find("PlayerHeroCard").GetComponent<HeroCard>().currentHealth;
        enemyCheck = GameObject.Find("EnemyHeroCard").GetComponent<EnemyHeroCard>().enemycurrentHealth;

        if (playerCheck <= 0 && enemyCheck > 0)
        {
            textObject.SetActive(true);
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            victoryText.text = "Defeat";
        }

        if (enemyCheck <= 0 && playerCheck > 0)
        {
            textObject.SetActive(true);
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            victoryText.text = "Victory";
        }

        if (playerCheck <= 0 && enemyCheck <=0)
        {
            textObject.SetActive(true);
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            victoryText.text = "Draw";
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Handles global hero rules and setup
public class HeroManager : MonoBehaviour
{
    public static HeroManager Instance;

    [Header("Hero References")]
    public HeroCard playerHero;

    public HeroCard enemyHero;

    [Header("Hero Rules")]
    public int startingHeroHealth = 20;

    [Header("Direct Attack Rules")]
    public bool allowDirectAttacks = true;

    public bool allowDirectAttackFirstTurn = false;

    [Header("Runtime Hero Health")]
    public int playerCurrentHealth;

    public int enemyCurrentHealth;

    [Header("Win State")]
    public bool gameEnded;

    public GameObject textObject;
    public GameObject playAgain;
    public GameObject mainMenu;
    public Text victoryText;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetupHeroes();
    }

    private void Update()
    {
        // Update runtime inspector values
        playerCurrentHealth =
            playerHero.currentHealth;

        enemyCurrentHealth =
            enemyHero.currentHealth;

        // Continuously monitor win conditions
        CheckWinCondition();
    }

    // Applies starting values to heroes
    private void SetupHeroes()
    {
        playerHero.currentHealth =
            startingHeroHealth;

        enemyHero.currentHealth =
            startingHeroHealth;
    }

    // Checks if a hero has lost
    public void CheckWinCondition()
    {
        // Prevent duplicate win calls
        if (gameEnded)
        {
            return;
        }

        if (playerCurrentHealth <= 0)
        {
            textObject.SetActive(true);
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            victoryText.text = "Defeat";
        }

        if (enemyCurrentHealth <= 0)
        {
            textObject.SetActive(true);
            playAgain.SetActive(true);
            mainMenu.SetActive(true);
            victoryText.text = "Victory";
        }
    }
}
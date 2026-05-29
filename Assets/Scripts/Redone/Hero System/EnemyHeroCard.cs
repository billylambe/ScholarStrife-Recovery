using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System;

// Represents a player or enemy hero
public class EnemyHeroCard : MonoBehaviour
{
    [Header("Hero Owner")]
    public CardOwner owner;

    [Header("Runtime Health")]
    public int enemycurrentHealth;
    public TMP_Text enemyhealthText;

    [Header("Runtime Mana")]
    public int enemycurrentMana;
    public TMP_Text enemymanaText;

    public static event Action OnEnemyLose; 

    //void Start()
    //{
    //    enemycurrentHealth = 20;
    //}

    private void FixedUpdate()
    {
        enemyhealthText.text = enemycurrentHealth.ToString();
        enemycurrentMana = GameObject.Find("Mana Manager").GetComponent<ManaManager>().enemyMana;
        enemymanaText.text = enemycurrentMana.ToString();
    }

    // Damages this hero
    public void TakeDamage(int amount)
    {
        enemycurrentHealth -= amount;

        HeroManager.Instance.CheckWinCondition();

        //if (currentHealth < 0)
        //{
        //    OnPlayerLose.Invoke();
        //}

        //if (currentHealth == 0)
        //{
        //    OnPlayerLose.Invoke();
        //}
    }

    //dynamic health diosplay

    //public void UpdateHealthText(int currentHealth)
    //{
    //    healthText.text = ""currentHealth.ToString();
    //}
}

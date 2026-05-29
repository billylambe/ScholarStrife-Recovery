using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System;

// Represents a player or enemy hero
public class HeroCard : MonoBehaviour
{
    [Header("Hero Owner")]
    public CardOwner owner;

    [Header("Runtime Health")]
    public int currentHealth;
    public TMP_Text healthText;

    [Header("Runtime Mana")]
    public int currentMana;
    public TMP_Text manaText;

    public static event Action OnPlayerLose;

    private void FixedUpdate()
    {
        healthText.text = currentHealth.ToString();
        currentMana = GameObject.Find("Mana Manager").GetComponent<ManaManager>().playerMana;
        manaText.text = currentMana.ToString();
    }

    // Damages this hero
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        HeroManager.Instance.CheckWinCondition();

        //if(currentHealth < 0) 
        //{
        //    OnPlayerLose.Invoke();
        //} 
        
        //if(currentHealth == 0)
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
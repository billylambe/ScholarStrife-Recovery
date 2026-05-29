using UnityEngine;
using TMPro;

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
    }

    //dynamic health diosplay

    //public void UpdateHealthText(int currentHealth)
    //{
    //    healthText.text = ""currentHealth.ToString();
    //}
}

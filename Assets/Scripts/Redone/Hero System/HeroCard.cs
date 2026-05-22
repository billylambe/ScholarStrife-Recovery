using UnityEngine;
using TMPro;

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
    }

    //dynamic health diosplay

    //public void UpdateHealthText(int currentHealth)
    //{
    //    healthText.text = ""currentHealth.ToString();
    //}
}
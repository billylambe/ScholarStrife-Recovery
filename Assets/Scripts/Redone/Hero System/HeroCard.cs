using UnityEngine;

// Represents a player or enemy hero
public class HeroCard : MonoBehaviour
{
    [Header("Hero Owner")]
    public CardOwner owner;

    [Header("Runtime Health")]
    public int currentHealth;

    // Damages this hero
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        HeroManager.Instance.CheckWinCondition();
    }
}
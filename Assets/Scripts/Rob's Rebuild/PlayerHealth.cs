using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 20;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(gameObject.name +
            " took " + damage +
            " damage. Remaining HP: " +
            currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log(gameObject.name + " lost the game.");
        }
    }
}
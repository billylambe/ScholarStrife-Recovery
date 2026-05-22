using UnityEngine;

public class ManaManager : MonoBehaviour
{
    public static ManaManager Instance;

    [Header("Player Mana")]
    public int playerMana = 1;

    [Header("Enemy Mana")]
    public int enemyMana = 1;

    private void Awake()
    {
        Instance = this;

        Debug.Log("ManaManager Awake");
    }

    private void Update()
    {
        Debug.Log(
            "LIVE MANA | Player: " +
            playerMana +
            " Enemy: " +
            enemyMana
        );
    }

    public bool HasEnoughMana(CardOwner owner, int cost)
    {
        if (owner == CardOwner.Player)
        {
            return playerMana >= cost;
        }

        return enemyMana >= cost;
    }

    public void SpendMana(CardOwner owner, int amount)
    {
        if (owner == CardOwner.Player)
        {
            playerMana -= amount;

            Debug.Log("Player spent " + amount + " mana.");
        }
        else
        {
            enemyMana -= amount;

            Debug.Log("Enemy spent " + amount + " mana.");
        }
    }

    public void SetMana(int amount)
    {
        Debug.Log("SetMana Called With: " + amount);

        playerMana = amount;

        Debug.Log("Player mana now: " + playerMana);
    }

    public void SetEnemyMana(int amount)
    {
        Debug.Log("SetEnemyMana Called With: " + amount);

        enemyMana = amount;

        Debug.Log("Enemy mana now: " + enemyMana);
    }
}
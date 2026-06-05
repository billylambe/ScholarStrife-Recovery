using UnityEngine;

public class IncrementalTurnM : MonoBehaviour
{
    public static IncrementalTurnM Instance;



    [Header("Current Turn")]
    public CardOwner currentTurn = CardOwner.Player;

    [Header("Mana Settings")]
    public int startingMana = 1;

    public int manaIncreasePerTurn = 1;

    public int maxMana = 10;

    private void Awake()
    {
        Instance = this;

        Debug.Log("TurnManager Awake");
    }

    private void Start()
    {
        Debug.Log("=== TURN MANAGER START ===");

        Debug.Log("Starting Mana Inspector Value: " + startingMana);

        ManaManager.Instance.SetMana(startingMana);

        ManaManager.Instance.SetEnemyMana(startingMana);

        Debug.Log("Player Mana Initialised To: " + ManaManager.Instance.playerMana);

        Debug.Log("Enemy Mana Initialised To: " + ManaManager.Instance.enemyMana);

        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        
        Debug.Log("=== PLAYER TURN START ===");

        currentTurn = CardOwner.Player;

        ManaManager.Instance.playerMana =
            Mathf.Min(
                ManaManager.Instance.playerMana +
                manaIncreasePerTurn,
                maxMana);

        Debug.Log("Player Mana After Regen: " + ManaManager.Instance.playerMana);

        ManaManager.Instance.playerMana = 0;
        ManaManager.Instance.playerMana = manaIncreasePerTurn + startingMana;

        ResetAttacks(CardOwner.Player);
    }

    public void EndPlayerTurn()
    {
        Debug.Log("=== PLAYER TURN END ===");

        StartEnemyTurn();
    }

    public void StartEnemyTurn()
    {
        Debug.Log("=== ENEMY TURN START ===");

        currentTurn = CardOwner.Enemy;

        ManaManager.Instance.enemyMana =
            Mathf.Min(
                ManaManager.Instance.enemyMana +
                manaIncreasePerTurn,
                maxMana);

        Debug.Log("Enemy Mana After Regen: " + ManaManager.Instance.enemyMana);


        ResetAttacks(CardOwner.Enemy);

        EnemyManager.Instance.TakeTurn();
    }

    public void EndEnemyTurn()
    {
        Debug.Log("=== ENEMY TURN END ===");

        StartPlayerTurn();
    }

    private void ResetAttacks(CardOwner owner)
    {
        CardCombat[] allCards =
            FindObjectsByType<CardCombat>(FindObjectsSortMode.None);

        foreach (CardCombat card in allCards)
        {
            if (card.owner == owner)
            {
                card.canAttack = true;
            }
        }
    }
}
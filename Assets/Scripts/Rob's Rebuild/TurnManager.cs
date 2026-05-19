using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    [Header("Turn Rules")]
    public bool autoDrawCards = true;

    [Header("Current Turn")]
    public CardOwner currentTurn = CardOwner.Player;

    [Header("Mana Settings")]
    public int startingMana = 1;

    public int maxMana = 10;

    private int playerMaxMana;

    private int enemyMaxMana;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerMaxMana = startingMana;

        enemyMaxMana = startingMana;

        StartPlayerTurn();
    }

    public void StartPlayerTurn()
    {
        currentTurn = CardOwner.Player;

        ManaManager.Instance.SetMana(playerMaxMana);

        if (autoDrawCards)
        {
            HandManager.Instance.DrawCardToHand(CardOwner.Player);
        }

        ResetAttacks(CardOwner.Player);

        Debug.Log("=== PLAYER TURN START ===");
    }

    public void EndPlayerTurn()
    {
        enemyMaxMana =
            Mathf.Min(enemyMaxMana + 1, maxMana);

        StartEnemyTurn();
    }

    public void StartEnemyTurn()
    {
        currentTurn = CardOwner.Enemy;

        ManaManager.Instance.SetEnemyMana(enemyMaxMana);

        if (autoDrawCards)
        {
            HandManager.Instance.DrawCardToHand(CardOwner.Enemy);
        }

        ResetAttacks(CardOwner.Enemy);

        Debug.Log("=== ENEMY TURN START ===");
    }

    public void EndEnemyTurn()
    {
        playerMaxMana =
            Mathf.Min(playerMaxMana + 1, maxMana);

        StartPlayerTurn();
    }

    private void ResetAttacks(CardOwner owner)
    {
        CardCombat[] allCards = FindObjectsByType<CardCombat>(FindObjectsSortMode.None);
            

        foreach (CardCombat card in allCards)
        {
            if (card.owner == owner)
            {
                card.canAttack = true;
            }
        }
    }
}
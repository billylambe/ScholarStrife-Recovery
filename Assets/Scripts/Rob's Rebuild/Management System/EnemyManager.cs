using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles extremely basic enemy AI behaviour
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [Header("AI Timing")]
    public float actionDelay = 0.5f;

    private void Awake()
    {
        Instance = this;
    }

    // Entry point for the enemy turn
    public void TakeTurn()
    {
        StartCoroutine(RunEnemyTurn());
    }

    private IEnumerator RunEnemyTurn()
    {
        yield return new WaitForSeconds(actionDelay);

        DrawCard();

        yield return new WaitForSeconds(actionDelay);

        PlayCards();

        yield return new WaitForSeconds(actionDelay);

        AttackPhase();

        yield return new WaitForSeconds(actionDelay);

        TurnManager.Instance.EndEnemyTurn();
    }

    // Draw a cards if allowed
    private void DrawCard()
    {
        while (HandManager.Instance.enemyHand.Count <
            HandManager.Instance.maxHandSize)
        {
            HandManager.Instance.DrawCardToHand(
                CardOwner.Enemy);

            Debug.Log("Enemy drew card/s.");
        }
    }

    // Play every affordable card
    private void PlayCards()
    {
        List<CardView> handCopy =
            new List<CardView>(HandManager.Instance.enemyHand);

        foreach (CardView card in handCopy)
        {
            int manaCost = card.CurrentData.manaCost;

            // Skip cards we cannot afford
            if (!ManaManager.Instance.HasEnoughMana(
                CardOwner.Enemy,
                manaCost))
            {
                continue;
            }

            // Find an empty enemy slot
            BoardSlot targetSlot = FindEmptySlot();

            // No space left on board
            if (targetSlot == null)
            {
                return;
            }

            // Spend mana
            ManaManager.Instance.SpendMana(
                CardOwner.Enemy,
                manaCost);

            // Move card to board
            CardCombat combat =
                card.GetComponent<CardCombat>();

            targetSlot.occupied = true;

            targetSlot.currentCard = card;

            combat.SetSlot(targetSlot);

            combat.isOnBoard = true;

            combat.canAttack = true;

            card.transform.SetParent(
                targetSlot.transform,
                false);

            RectTransform rect =
                card.GetComponent<RectTransform>();

            rect.localPosition = Vector3.zero;

            // Remove from hand
            HandManager.Instance.enemyHand.Remove(card);

            // Add to board tracking
            BoardManager.Instance.AddToBoard(card);

            Debug.Log("Enemy played: " +
                card.CurrentData.cardName);
        }
    }

    // Attack using every active enemy card
    private void AttackPhase()
    {
        List<CardCombat> enemyCards =
            GetBoardCards(CardOwner.Enemy);

        List<CardCombat> playerCards =
            GetBoardCards(CardOwner.Player);

        foreach (CardCombat attacker in enemyCards)
        {
            // Ignore dead cards
            if (attacker == null)
            {
                continue;
            }

            // Ignore exhausted cards
            if (!attacker.canAttack)
            {
                continue;
            }

            // Attack player cards first
            if (playerCards.Count > 0)
            {
                CardCombat target = playerCards[0];

                if (target != null)
                {
                    attacker.AttackCard(target);

                    attacker.canAttack = false;

                    // Remove dead targets
                    if (target.isDead)
                    {
                        playerCards.Remove(target);
                    }

                    Debug.Log(
                        attacker.name +
                        " attacked " +
                        target.name);
                }
            }

            // Otherwise attack hero
            else
            {
                int attackValue =
                    attacker.GetComponent<CardView>()
                    .CurrentData.attack;

                HeroManager.Instance.playerHero
                    .TakeDamage(attackValue);

                attacker.canAttack = false;

                Debug.Log(
                    attacker.name +
                    " attacked player hero for " +
                    attackValue);
            }
        }
    }

    // Find empty enemy board slot
    private BoardSlot FindEmptySlot()
    {
        BoardSlot[] allSlots =
            FindObjectsByType<BoardSlot>(
                FindObjectsSortMode.None);

        foreach (BoardSlot slot in allSlots)
        {
            if (slot.owner != CardOwner.Enemy)
            {
                continue;
            }

            if (!slot.occupied)
            {
                return slot;
            }
        }

        return null;
    }

    // Get all cards currently on board
    private List<CardCombat> GetBoardCards(
        CardOwner owner)
    {
        List<CardCombat> results =
            new List<CardCombat>();

        CardCombat[] allCards =
            FindObjectsByType<CardCombat>(
                FindObjectsSortMode.None);

        foreach (CardCombat card in allCards)
        {
            if (card.owner != owner)
            {
                continue;
            }

            if (!card.isOnBoard)
            {
                continue;
            }

            if (card.isDead)
            {
                continue;
            }

            results.Add(card);
        }

        return results;
    }
}
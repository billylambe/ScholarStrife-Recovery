using UnityEngine;

// Handles runtime combat behaviour for a card
public class CardCombat : MonoBehaviour
{
    private CardView cardView;

    // The board slot this card currently occupies
    private BoardSlot currentSlot;

    // Runtime health value
    public int currentHealth;

    public bool isDead = false;

    public CardOwner owner;

    public bool isOnBoard = false;

    private void Awake()
    {
        // Cache CardView reference
        cardView = GetComponent<CardView>();
    }

    private void Start()
    {
        // Runtime health starts equal to the card's base health
        currentHealth = cardView.CurrentData.health;

        // Update health text visually
        cardView.UpdateHealthText(currentHealth);
    }

    // Called when this card is placed onto a slot
    public void SetSlot(BoardSlot slot)
    {
        currentSlot = slot;
    }

    // Called when this card takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log(
            cardView.CurrentData.cardName +
            " took " +
            damage +
            " damage."
        );

        // Update health text
        cardView.UpdateHealthText(currentHealth);

        // Check if the card died
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Attack another card
    public void AttackCard(CardCombat target)
    {
        int myAttack =
            cardView.CurrentData.attack;

        int targetAttack =
            target.cardView.CurrentData.attack;

        // Attacker deals damage first
        target.TakeDamage(myAttack);

        // Defender only retaliates if still alive
        if (!target.isDead)
            {
            TakeDamage(targetAttack);
        }

        Debug.Log(
            cardView.CurrentData.cardName +
            " attacked " +
            target.cardView.CurrentData.cardName
        );
    }

    // Attack a player directly
    public void AttackPlayer(PlayerHealth player)
    {
        int myAttack = cardView.CurrentData.attack;

        player.TakeDamage(myAttack);

        Debug.Log(
            cardView.CurrentData.cardName +
            " attacked the player for " +
            myAttack
        );
    }

    // Destroy this card
    private void Die()
    {
        isDead = true;

        Debug.Log(
            cardView.CurrentData.cardName +
            " died."
        );

        if (currentSlot != null)
        {
            currentSlot.occupied = false;
            currentSlot.currentCard = null;
        }

        BoardManager.Instance.cardsOnBoard.Remove(cardView);

        Destroy(gameObject);
    }
}
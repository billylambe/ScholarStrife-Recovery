using UnityEngine;
using UnityEngine.EventSystems;

// Handles clicking on hero cards
public class HeroTargeting : MonoBehaviour,
    IPointerClickHandler
{
    private HeroCard hero;

    private void Awake()
    {
        hero = GetComponent<HeroCard>();
    }

    public void OnPointerClick(
        PointerEventData eventData
    )
    {
        // No attacker selected
        if (CardTargeting.selectedAttacker == null)
        {
            return;
        }

        CardCombat attacker =
            CardTargeting.selectedAttacker;

        // Prevent attacking own hero
        if (attacker.owner == hero.owner)
        {
            return;
        }

        // Check if direct attacks are allowed
        if (!HeroManager.Instance.allowDirectAttacks)
        {
            Debug.Log(
                "Direct attacks are disabled."
            );

            return;
        }

        // Prevent direct attacks if defenders exist
        if (BoardManager.Instance
            .HasCardsOnBoard(hero.owner))
        {
            Debug.Log(
                "Cannot direct attack while defenders exist."
            );

            return;
        }

        // Get attack value from card data
        int attackValue =
            attacker.GetComponent<CardView>()
                .CurrentData.attack;

        // Damage hero
        hero.TakeDamage(attackValue);

        // Consume attack
        attacker.canAttack = false;

        // Clear attacker
        CardTargeting.selectedAttacker = null;

        Debug.Log(attacker.name +
            " attacked " +
            hero.owner +
            " hero for " +
            attackValue +
            " damage.");
    }
}
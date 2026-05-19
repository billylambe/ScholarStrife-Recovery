using UnityEngine;
using UnityEngine.EventSystems;

public class CardTargeting : MonoBehaviour,
    IPointerClickHandler
{
    private static CardCombat selectedAttacker;

    private CardCombat myCombat;

    private void Awake()
    {
        myCombat = GetComponent<CardCombat>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Ignore cards not on the board
        if (!myCombat.isOnBoard)
        {
            return;
        }

        // First click selects attacker
        if (selectedAttacker == null)
        {
            // Cannot attack twice in one turn
            if (!myCombat.canAttack)
            {
                Debug.Log("Card already attacked this turn.");

                return;
            }

            selectedAttacker = myCombat;

            Debug.Log(myCombat.name +
                " selected as attacker.");

            return;
        }

        // Prevent attacking self
        if (selectedAttacker == myCombat)
        {
            selectedAttacker = null;

            return;
        }

        // Prevent friendly attacks
        if (selectedAttacker.owner == myCombat.owner)
        {
            Debug.Log("Cannot attack friendly cards.");

            selectedAttacker = null;

            return;
        }

        // Resolve combat
        CombatManager.Instance.ResolveCardAttack(
            selectedAttacker,
            myCombat);

        // Mark attacker as used
        selectedAttacker.canAttack = false;

        // Clear selection
        selectedAttacker = null;
    }
}
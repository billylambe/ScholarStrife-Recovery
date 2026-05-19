using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public CardCombat selectedAttacker;

    private void Awake()
    {
        Instance = this;
    }

    // Card vs card combat
    public void ResolveCardAttack(
        CardCombat attacker,
        CardCombat defender)
    {
        attacker.AttackCard(defender);
        CombatManager.Instance.ResetSelection();
    }

    // Card attacks player directly
    public void ResolvePlayerAttack(
        CardCombat attacker,
        PlayerHealth targetPlayer)
    {
        attacker.AttackPlayer(targetPlayer);
    }

    // Reset selections after attacks
    public void ResetSelection()
    {
        selectedAttacker = null;
    }
}
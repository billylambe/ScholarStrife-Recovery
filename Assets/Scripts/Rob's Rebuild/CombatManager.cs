using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

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
    }

    // Card attacks player directly
    public void ResolvePlayerAttack(
        CardCombat attacker,
        PlayerHealth targetPlayer)
    {
        attacker.AttackPlayer(targetPlayer);
    }
}
using UnityEngine;
// Game Manager that keeps track of current mana resources
// We're not putting it inside the card system itself, which from going through your codebase it looks like you were attempting.

//If the logic fails it fails everywhere not on singular broken cards
// Therefore we check the logic here to fix it
public class ManaManager : MonoBehaviour
{
    public static ManaManager Instance;

    public int currentMana = 3;

    private void Awake()
    {
        Instance = this; // Set to an instance
        Debug.Log($"[Mana Manager] - Current Mana = {currentMana}");
    }

    public bool HasEnoughMana(int cost) // Checks whether the player has enough mana for the requested action
    {
        Debug.Log($"[Mana Manager] - Mana Check returned - {currentMana >= cost}");
        return currentMana >= cost;
        
    }

    public void SpendMana(int amount) // Spends Mana when called
    {
        currentMana -= amount;
        Debug.Log($"[Mana Manager] - Mana Spent: {amount}, current Mana: {currentMana}");
    }
}
using UnityEngine;

// This is NOT a MonoBehaviour.
// This is just a plain data class.

[System.Serializable]
public class CardData
{
    public string cardName;
    public int manaCost;
    public int attack;
    public int health;
    public string description;
}

// It only stores the properties a card will hold. Add more fields here as you need them
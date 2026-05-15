using UnityEngine;

public class CardTester : MonoBehaviour
{
    public CardView testCard;
    public int indexNumber = 0;
    private int currentIndex;

    private void Start() // set the starting index card
    {
        testCard.Setup(CardDatabase.Instance.allCards[indexNumber]);
        currentIndex = indexNumber;
    }

    private void Update() // if we change it, update it
    {
        if (currentIndex != indexNumber)
            {
            testCard.Setup(CardDatabase.Instance.allCards[indexNumber]);
            currentIndex = indexNumber;
        }
    }
}
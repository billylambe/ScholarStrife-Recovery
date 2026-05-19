using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text nameText;
    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text healthText;
    public TMP_Text descriptionText;

    private CardData currentData;

    public CardData CurrentData
    {
        get { return currentData; }
    }

    public void Setup(CardData newData)
    {
        currentData = newData;

        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        nameText.text = CurrentData.cardName;
        manaText.text = CurrentData.manaCost.ToString();
        attackText.text = CurrentData.attack.ToString();
        descriptionText.text = CurrentData.description;
    }

    // Runtime combat health updates
    public void UpdateHealthText(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }
}
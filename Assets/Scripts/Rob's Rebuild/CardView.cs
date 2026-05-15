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

    public void Setup(CardData newData)
    {
        currentData = newData;

        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        nameText.text = currentData.cardName;
        manaText.text = currentData.manaCost.ToString();
        attackText.text = currentData.attack.ToString();
        healthText.text = currentData.health.ToString();
        descriptionText.text = currentData.description;
    }
}
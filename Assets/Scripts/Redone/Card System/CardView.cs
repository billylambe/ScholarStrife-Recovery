using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text nameText;
    public TMP_Text manaText;
    public TMP_Text attackText;
    public TMP_Text healthText;
    public TMP_Text descriptionText;
    public Sprite cardSprite;
    public Image artworkSlot;

    private CardData currentData;


    public CardData CurrentData
    {
        get { return currentData; }
    }

    [SerializeField] ArtworkManager artworkManager;

    private void Awake()
    {
        if (artworkManager == null)
        {
            artworkManager = FindFirstObjectByType<ArtworkManager>();
        }
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
        cardSprite = artworkManager.GetArtwork(CurrentData.cardName);
        artworkSlot.sprite = cardSprite;
    }

    // Runtime combat health updates
    public void UpdateHealthText(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }
}
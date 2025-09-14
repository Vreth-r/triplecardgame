using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInstance : MonoBehaviour
{
    public CardData cardData;

    public DropzoneType type;

    [Header("UI References")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI descriptionText;

    void Start()
    {
        if (cardData != null)
            LoadCard(cardData);
    }

    public void LoadCard(CardData data)
    {
        cardData = data;
        type = data.type;
        nameText.text = data.cardName;
        manaText.text = data.manaCost.ToString();
        attackText.text = data.attack.ToString();
        healthText.text = data.health.ToString();
        descriptionText.text = data.description;
    }
}

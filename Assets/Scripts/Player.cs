using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Decks")]
    public DeckManager dawnDeck;
    public DeckManager dayDeck;
    public DeckManager duskDeck;

    [Header("Hands")]
    public HandManager dawnHand;
    public HandManager dayHand;
    public HandManager duskHand;

    [Header("Player Info")]
    public string playerName;
    public int mana;
    public int maxMana;

    // Draws one card from the selected deck-hand pair
    public void DrawCard(string pool)
    {
        switch (pool.ToLower())
        {
            case "dawn":
                dawnDeck.DrawCardToHand(dawnHand);
                break;
            case "day":
                dayDeck.DrawCardToHand(dayHand);
                break;
            case "dusk":
                duskDeck.DrawCardToHand(duskHand);
                break;
            default:
                Debug.LogWarning($"Invalid pool name: {pool}");
                break;
        }
    }

    public void DrawAll()
    {
        DrawCard("dawn");
        DrawCard("day");
        DrawCard("dusk");
    }

    public void GainMana()
    {
        // will work in tri mana later
        maxMana = Mathf.Min(maxMana + 1, 10);
        mana = maxMana;
    }
}

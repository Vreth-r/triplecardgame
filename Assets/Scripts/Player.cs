using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<CardData> deck = new List<CardData>();
    public List<CardInstance> hand = new List<CardInstance>();
    public Transform handArea; // Where cards spawn in UI
    public GameObject cardPrefab;

    public void DrawCard()
    {
        if (deck.Count == 0) return;

        CardData drawn = deck[0];
        deck.RemoveAt(0);

        GameObject cardGO = Instantiate(cardPrefab, handArea);
        CardInstance instance = cardGO.GetComponent<CardInstance>();
        instance.LoadCard(drawn);

        hand.Add(instance);
    }
}

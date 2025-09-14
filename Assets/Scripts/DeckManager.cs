using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [Header("Deck Setup")]
    public List<CardData> startingDeck;
    private Queue<CardData> deckQueue;
    public DropzoneType type;

    void Awake()
    {
        deckQueue = new Queue<CardData>(startingDeck);
    }

    public void DrawCardToHand(HandManager handManager)
    {
        if (deckQueue.Count == 0)
        {
            Debug.Log("Deck is empty!");
            return;
        }

        CardData drawnCard = deckQueue.Dequeue();
        handManager.AddCardToHand(drawnCard);
    }
}

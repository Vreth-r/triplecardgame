using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [Header("Deck Setup")]
    public List<CardData> startingDeck; // fill with ScriptableObjects in Inspector
    private Queue<CardData> deckQueue;
    public DropzoneType type;

    [Header("References")]
    public HandManager handManager;

    void Start()
    {
        // Copy deck into queue
        deckQueue = new Queue<CardData>(startingDeck);
    }

    public void DrawCard()
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

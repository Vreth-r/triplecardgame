using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [Header("Hand Settings")]
    public Transform handArea; // Empty GameObject where cards will spawn
    public GameObject cardPrefab;
    public float cardSpacing = 2f; // spacing between cards in hand
    public float handYOffset = 0f; // keep all cards aligned on table

    private List<GameObject> cardsInHand = new List<GameObject>();

    public DropzoneType type;

    public void AddCardToHand(CardData cardData)
    {
        GameObject newCard = Instantiate(cardPrefab, handArea);
        var cardInstance = newCard.GetComponent<CardInstance>();
        if (cardInstance != null)
        {
            cardInstance.LoadCard(cardData);
        }

        cardsInHand.Add(newCard);
        ArrangeHand();
    }

    public void RemoveCardFromHand(GameObject card)
    {
        if (cardsInHand.Contains(card))
        {
            cardsInHand.Remove(card);
            ArrangeHand();
        }
    }

    private void ArrangeHand()
    {
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            //Vector3 pos = handArea.position + new Vector3(i * cardSpacing, handYOffset, 0);
            Vector3 pos = new Vector3(i * cardSpacing, handYOffset, 0);
            cardsInHand[i].transform.localPosition = pos;
            cardsInHand[i].transform.localRotation = Quaternion.identity;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab; //assign in inspector
    public Transform handTransform; //root of the hand position
    public float fanSpread = -5.0f;
    public float cardHorizontalSpacing = 222.0f;
    public float cardVerticalSpacing = 80.0f;
    public int maxHandSize;
    public List<GameObject> cardsInHand = new List<GameObject>(); // hold a list of card object in our hand

    void Start()
    {

    }
    private void Update()
    {
        //UpdateHandVisuals();
    }

    public void BattleSetup(int setHandSize)
    {
        maxHandSize = setHandSize;
    }

    public void AddCardToHand(AbstractCard cardData)
    {
        //Instantiate our card
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        newCard.GetComponent<CardDisplay>().cardDate = cardData;
        UpdateHandVisuals();
    }

    private void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;
        if (cardCount < 0)// skip calculations when we have no card in hand
        {
            Debug.LogError("Card Count below 0, shouldn't happend. fix it");
            return;
        }
        else if (cardCount == 1) //No need for offset when we have only 1 card
        {
            cardsInHand[0].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            cardsInHand[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            return;
        }
        for (int i = 0; i < cardCount; i++)
        {
            float rotateAngle = (fanSpread * (i - (cardCount - 1) / 2.0f));
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotateAngle);
            float horizontalOffset = cardHorizontalSpacing * (i - (cardCount - 1) / 2.0f);
            float normalizedPosition = (2.0f * i / (cardCount - 1) - 1.0f); //normalized the all the card position between -1:1
            float verticalOffset = cardVerticalSpacing * (1 - normalizedPosition * normalizedPosition);

            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }


    }

    
}

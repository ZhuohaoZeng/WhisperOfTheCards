using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrawPileManager : MonoBehaviour
{
    public List<AbstractCard> drawPile = new List<AbstractCard>();
    
    public int currentIndex = 0;
    public int maxHandSize;
    public int currentHandSize;
    private HandManager handManager;
    private DiscardManager discardManager;
    public TextMeshProUGUI drawPileCounter;

    // Start is called before the first frame update
    void Start()
    {
       handManager = FindObjectOfType<HandManager>();
       discardManager = FindObjectOfType<DiscardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (handManager != null)
        {
            currentHandSize = handManager.cardsInHand.Count;
        }
    }

    public void MakeDrawPile(List<AbstractCard> cardsToAdd)
    {
        drawPile.AddRange(cardsToAdd);
        Utility.Shuffle(drawPile);
        UpdateDrawPileCount();
    }
    
    public void BattleSetup(int numberOfCardsToDraw, int setMaxHandSize)
    {
        maxHandSize = setMaxHandSize;
        for (int i = 0; i < numberOfCardsToDraw; i++)
        {
            DrawCard(handManager);
        }
    }

    public void DrawCard(HandManager handManager)
    {
        if (drawPile.Count == 0) {
            RefillPileFromDiscardPile();
        }
        if (currentHandSize < maxHandSize)
        {
            AbstractCard card = drawPile[currentIndex];
            handManager.AddCardToHand(card);
            drawPile.RemoveAt(currentIndex);
            UpdateDrawPileCount();
            if (drawPile.Count > 0) currentIndex %= drawPile.Count; //Ensuring currentIndex will never longer than the length of all cards
        }

    }

    private void RefillPileFromDiscardPile()
    {
        if (discardManager == null)
        {
            discardManager = FindObjectOfType<DiscardManager>();
        }

        if (discardManager != null && discardManager.discardCardsCount > 0)
        {
            drawPile = discardManager.PullAllCardFromDiscard();
            Utility.Shuffle(drawPile);
            currentIndex = 0;
        }
    }

    private void UpdateDrawPileCount()
    {
        drawPileCounter.text = drawPile.Count.ToString();
    }
}

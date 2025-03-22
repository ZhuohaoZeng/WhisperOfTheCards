using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<AbstractCard> allCards = new List<AbstractCard>();
    public int maxHandSize = 12;
    public int startingHandSize = 1;
    public int currentHandSize;
    private HandManager handManager;
    private DrawPileManager drawPileManager;
    private bool startBattleRun = true;
    public int testingNumberOfCardInPile;

    void Awake()
    {
        if (handManager == null)
        {
            handManager = FindObjectOfType<HandManager>();
        }   
        if (drawPileManager == null)
        {
            drawPileManager = FindObjectOfType<DrawPileManager>();
        }
    }
    void Start()
    {
        AbstractCard[] cards = Resources.LoadAll<AbstractCard>("Cards");//Since I only have 1 card designed at this very early stage
        //I will add this card multiple times to test it 
        for (int i = 0; i < testingNumberOfCardInPile; i++)
        {
            allCards.AddRange(cards);
        }
        
    }

    void Update()
    {
        if (startBattleRun)
        {
            BattleSetup();
        }
    }

    public void BattleSetup()
    {
        handManager.BattleSetup(maxHandSize);
        drawPileManager.MakeDrawPile(allCards);
        drawPileManager.BattleSetup(startingHandSize, maxHandSize);
        startBattleRun = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiscardManager : MonoBehaviour
{
    [SerializeField] public List<AbstractCard> discardCards = new List<AbstractCard>();
    public TextMeshProUGUI discardCount;
    public int discardCardsCount;

    void Awake()
    {
        UpdateDiscardCount();
    }

    private void UpdateDiscardCount()
    {
        discardCount.text = discardCards.Count.ToString();
        discardCardsCount = discardCards.Count;
    }

    public void AddToDiscard(AbstractCard card)
    {
        if (card != null)
        {
            discardCards.Add(card);
            UpdateDiscardCount();
        }
    }

    public AbstractCard PullFromDiscard()
    {
        if (discardCards.Count > 0)
        {
            AbstractCard returnCard = discardCards[discardCards.Count - 1];
            discardCards.RemoveAt(discardCards.Count - 1);
            UpdateDiscardCount();
            return returnCard;
        }
        else
        {
            return null;
        }
    }

    public bool PullSelectedCardFromDiscard(AbstractCard selectedCard)
    {
        if (discardCards.Count > 0 && discardCards.Contains(selectedCard))
        {
            discardCards.Remove(selectedCard);
            UpdateDiscardCount();
            return true;
        }
        else
        {
            return false;
        }
    }
    public List<AbstractCard> PullAllCardFromDiscard()
    {
        if (discardCards.Count > 0)
        {
            List<AbstractCard> retunCards = new List<AbstractCard>(discardCards);
            discardCards.Clear();
            UpdateDiscardCount();
            return retunCards;
        }
        else
        {
            return new List<AbstractCard>();
        }
    }
}

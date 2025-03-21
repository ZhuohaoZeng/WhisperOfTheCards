using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class CardDisplay : MonoBehaviour
{
    public AbstractCard cardDate;
    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text costText;
    public TMP_Text damageText;
    public Image[] typeImages;

    void Start()
    {
        UpdateCardDisplay();    
    }

    private void UpdateCardDisplay()
    {
        nameText.text = cardDate.cardName;
        costText.text = cardDate.cost.ToString();
        damageText.text = cardDate.damage.ToString();
    }
}

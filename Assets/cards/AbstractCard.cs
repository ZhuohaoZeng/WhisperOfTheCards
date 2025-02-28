using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class AbstractCard : ScriptableObject
    //STS implements Comparable<AbstractCard>
    //I wonder why did he need CompareTo Method?
    //Is there any spcial cases he need to compare if 2 card are the same?
{
    public Sprite Sprite;
    public List<CardType> type;
    public string cardName;
    public int damage;
    public List<DamageType> damageType;
    public int cost;
    public int costForTurn;
    public int price;
    public int chargeCost;
    public Boolean isCostModified;
    public Boolean isCostModifiedForTurn;
    public int heal;
    public int draw;
}





public enum CardType
{
    ATTACK,
    SKILL,
    POWER,
    STATUS,
    CURSE
}

public enum DamageType
{
    NORMAL, THORNS, HP_LOSS
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCard : ScriptableObject
    //STS implements Comparable<AbstractCard>
    //I wonder why did he need CompareTo Method?
    //Is there any spcial cases he need to compare if 2 card are the same?
{
    public CardType type;
    public int cost;
    public int costForTurn;
    public int price;
    public int chargeCost;
    public Boolean isCostModified;
    public Boolean isCostModifiedForTurn;
    public int damege;
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
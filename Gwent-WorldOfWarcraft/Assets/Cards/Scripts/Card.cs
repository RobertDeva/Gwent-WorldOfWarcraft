using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string CardName;
    public int Attack;
    public Faction CardFaction;
    public CardTipe Cardtipe;
    public Position Position1;
    public Position Position2;
    public Position Position3;
    public Rank CardRank;
    public string Description;
    public Sprite CardFront;

    public bool InField = false;
    public bool Upgraded = false;
    public bool AffectedByWeather = false;
    public bool Buffed = false;
    public bool Debuffed = false;
    public bool BondInField = false;
    






    public enum Faction 
    { 
        Horde,
        Alliance,
        Neutral
    }
    public enum CardTipe
    {
        Leader,
        Weather,
        ClearWeather,
        Lure,
        Upgrade,
        Unit
    }
    public enum Position
    {
        M,
        R,
        S,
        U,
        C
    }
    public enum Rank
    {
        Special,
        Gold,
        Silver
    }
    public enum Effect
    {
        Upgrade,
        Weather,
        ClearWeather,
        Lure,
        DestroyCard,
        CardUp,
        CardDown,
        SaveCard,
        NoEffect
    }
}

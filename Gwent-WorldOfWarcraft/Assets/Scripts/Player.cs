using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GwentEngine;

public class Player : MonoBehaviour
{
    public List<Card> cards;

    
    public bool Played = false;
    public bool Passed = false;
    public bool Drawed = false;
    public bool IsPlaying = false;
    public bool StartPlay = false;

    public Leader Leader;
    public GameObject MeleeZone;
    public GameObject RangeZone;
    public GameObject SiegeZone;
    public GameObject MeleeBuff;
    public GameObject RangeBuff;
    public GameObject SiegeBuff;
    public Stack<Card> Deck;

    int MeleeLinePower = 0;
    int RangeLinePower = 0;
    int SiegeLinePower = 0;
    int TotalPower = 0;

    public TMP_Text MLP;
    public TMP_Text RLP;
    public TMP_Text SLP;
    public TMP_Text TP;

    public void GetLinePower(GameObject LineZone)
    {
        int LinePower = 0;
        List<CardDisplay> list = new List<CardDisplay>();
        foreach(Transform card in LineZone.transform)
        {
            CardDisplay carta = card.GetComponent<CardDisplay>();
            if(carta != null)
            {
                list.Add(carta);
            }
        }
        foreach(CardDisplay carta in list)
        {
            Card.Rank rank = carta.CardRank;
            Card.CardTipe tipe = carta.Cardtipe;
            int Power = carta.AttackPower;
            bool x = carta.Buffed;
            bool y = carta.Debuffed;
            bool z = carta.Upgraded;
            bool a = carta.AffectedByWeather;

            if(tipe == Card.CardTipe.Unit)
            {
                if(rank == Card.Rank.Silver)
                {
                    if(x == true || z == true)
                    {
                        Power *= 2;
                    }
                    if(y == true || a == true)
                    {
                        Power = Power / 2 + Power % 2;
                    }
                    LinePower += Power;
                }
                else
                {
                    LinePower += Power;
                }
            }

            else
            {
                LinePower += 0;
            }


        }
        if(LineZone == MeleeZone)
        {
            MeleeLinePower = LinePower;
        }
        else if(LineZone == RangeZone)
        {
            RangeLinePower = LinePower;
        }
        else if(LineZone == SiegeZone)
        {
            SiegeLinePower = LinePower;
        }

        
    }
    
    public void GetTotalPower()
    {
        TotalPower = MeleeLinePower + RangeLinePower + SiegeLinePower;
    }
    public int GetFinalPower()
    {
        int Power = TotalPower;
        return Power;
    }

    public void Pass()
    {
        if (IsPlaying == true)
        {
            if (Played == false)
                Passed = true;
            IsPlaying = false;
        }
    }
    List<Card> Shuffle(List<Card> cards)
    {
        System.Random random = new();
        List<Card> list = new();

        while (cards.Count > 0)
        {
            int index = random.Next(0, cards.Count);
            list.Add(cards[index]);
            cards.RemoveAt(index);
        }
        return list;
    }
   

    private void Start()
    {
    }
    void Update()
     {
        if(IsPlaying == false || Played == true && Passed == false)
        {
            GetLinePower(MeleeZone);
            GetLinePower(RangeZone);
            GetLinePower(SiegeZone);
            GetTotalPower();
        }
        MLP.text = MeleeLinePower.ToString();
        RLP.text = RangeLinePower.ToString();
        SLP.text = SiegeLinePower.ToString();
        TP.text = TotalPower.ToString();
     }

}
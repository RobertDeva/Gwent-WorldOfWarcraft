using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GwentEngine;

public class Player : MonoBehaviour
{
    public bool Played = false;
    public bool Passed = false;
    public bool Drawed = false;
    public bool IsPlaying = false;
    public bool StartPlay = false;

    GameObject Leader;
    public List<GameObject> Deck;
    public List<GameObject> Cementery;
    public List<GameObject> Hand;
    public List<GameObject> MeleeZone;
    public List<GameObject> RangeZone;
    public List<GameObject> SiegeZone;
    public List<GameObject> MeleeBuff;
    public List<GameObject> RangeBuff;
    public List<GameObject> SiegeBuff;

    int MeleeLinePower = 0;
    int RangeLinePower = 0;
    int SiegeLinePower = 0;
    int TotalPower = 0;

    public TMP_Text MLP;
    public TMP_Text RLP;
    public TMP_Text SLP;
    public TMP_Text TP;

    public void GetMeleePower()
    {
        MeleeLinePower = 0;
        foreach (GameObject x in MeleeZone)
        {
            int Attack = x.GetComponent<CardDisplay>().AttackPower;
            var tipe = x.GetComponent<CardDisplay>().Cardtipe;
            var rank = x.GetComponent<CardDisplay>().CardRank;
            var a = x.GetComponent<CardDisplay>().AffectedByWeather;
            var b = x.GetComponent<CardDisplay>().Buffed;
            var c = x.GetComponent<CardDisplay>().Upgraded;
            var d = x.GetComponent<CardDisplay>().Debuffed;
            if(tipe == Card.CardTipe.Unit && rank == Card.Rank.Silver)
            {
                
                if(a == true)
                {
                    Attack = Attack / 2 + Attack % 2; 
                }
                if(b == true || c == true)
                {
                    Attack = Attack * 2;
                }
                if(d == true)
                {
                    Attack = Attack  /2 + Attack % 2;
                }
                MeleeLinePower += Attack;
            }
            else if(tipe == Card.CardTipe.Unit)
            {
                MeleeLinePower += Attack;
            }
            else
            {
                MeleeLinePower += 0;
            }
        }
    }
    public void GetRangePower()
    {
        RangeLinePower = 0;
        foreach (GameObject x in RangeZone)
        {
            int Attack = x.GetComponent<CardDisplay>().AttackPower;
            var tipe = x.GetComponent<CardDisplay>().Cardtipe;
            var rank = x.GetComponent<CardDisplay>().CardRank;
            var a = x.GetComponent<CardDisplay>().AffectedByWeather;
            var b = x.GetComponent<CardDisplay>().Buffed;
            var c = x.GetComponent<CardDisplay>().Upgraded;
            var d = x.GetComponent<CardDisplay>().Debuffed;
            if (tipe == Card.CardTipe.Unit && rank == Card.Rank.Silver)
            {

                if (a == true)
                {
                    Attack = Attack / 2 + Attack % 2;
                }
                if (b == true || c == true)
                {
                    Attack = Attack * 2;
                }
                if (d == true)
                {
                    Attack = Attack / 2 + Attack % 2;
                }
                RangeLinePower += Attack;
            }
            else if (tipe == Card.CardTipe.Unit)
            {
                RangeLinePower += Attack;
            }
            else
            {
                RangeLinePower += 0;
            }
        }
    }
    public void GetSiegePower()
    {
        SiegeLinePower = 0;
        foreach (GameObject x in SiegeZone)
        {
            int Attack = x.GetComponent<CardDisplay>().AttackPower;
            var tipe = x.GetComponent<CardDisplay>().Cardtipe;
            var rank = x.GetComponent<CardDisplay>().CardRank;
            var a = x.GetComponent<CardDisplay>().AffectedByWeather;
            var b = x.GetComponent<CardDisplay>().Buffed;
            var c = x.GetComponent<CardDisplay>().Upgraded;
            var d = x.GetComponent<CardDisplay>().Debuffed;
            if (tipe == Card.CardTipe.Unit && rank == Card.Rank.Silver)
            {

                if (a == true)
                {
                    Attack = Attack / 2 + Attack % 2;
                }
                if (b == true || c == true)
                {
                    Attack = Attack * 2;
                }
                if (d == true)
                {
                    Attack = Attack / 2 + Attack % 2;
                }
                SiegeLinePower += Attack;
            }
            else if (tipe == Card.CardTipe.Unit)
            {
                SiegeLinePower += Attack;
            }
            else
            {
                SiegeLinePower += 0;
            }
        }
    }
    public void GetTotalPower()
    {
        TotalPower = MeleeLinePower + RangeLinePower + SiegeLinePower;
    }

     void Update()
     {
        if(Played == true && Passed == false)
        {
            GetMeleePower();
            GetRangePower();
            GetSiegePower();
            GetTotalPower();
        }
        MLP.text = MeleeLinePower.ToString();
        RLP.text = RangeLinePower.ToString();
        SLP.text = SiegeLinePower.ToString();
        TP.text = TotalPower.ToString();
     }

    public void CleanField()
    {
        foreach(GameObject x in MeleeZone)
        {
            if (x.GetComponent<CardDisplay>().BondInField == false)
            {
                Cementery.Add(x);
                MeleeZone.Remove(x);
            }
        }
        foreach(GameObject y in RangeZone)
        {
            if (y.GetComponent<CardDisplay>().BondInField == false)
            {
                Cementery.Add(y);
                MeleeZone.Remove(y);
            }
        }
        foreach(GameObject z in SiegeZone)
        {
            if (z.GetComponent<CardDisplay>().BondInField == false)
            {
                Cementery.Add(z);
                MeleeZone.Remove(z);
            }
        }
    }

}

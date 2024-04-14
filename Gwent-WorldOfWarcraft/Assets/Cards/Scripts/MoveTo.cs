using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GwentEngine;

public class MoveTo: MonoBehaviour
{
    GameObject P1;
    GameObject P2;
    GameObject HandP1;
    GameObject HandP2;
    GameObject DeckP1;
    GameObject DeckP2;
    GameObject MeleeP1;
    GameObject MeleeP2;
    GameObject RangeP1;
    GameObject RangeP2;
    GameObject SiegeP1;
    GameObject SiegeP2;
    GameObject MeleeUpP1;
    GameObject MeleeUpP2;
    GameObject RangeUpP1;
    GameObject RangeUpP2;
    GameObject SiegeUpP1;
    GameObject SiegeUpP2;
    GameObject MeleeWheather;
    GameObject RangeWheather;
    GameObject SiegeWheather;
    public AudioSource WheaterSet;
    public AudioSource UnitSet;
    public AudioSource UpgadeSet;
    readonly int WheatherLimit = 1;

    Transform startParent;

    private void Start()
    {
        startParent = transform.parent;
        P1 = GameObject.Find("Player1");
        P2 = GameObject.Find("Player2");
        DeckP1 = GameObject.Find("DeckP1");
        DeckP2 = GameObject.Find("DeckP2");
        HandP1 = GameObject.Find("HandP1");
        HandP2 = GameObject.Find("HandP2");
        MeleeP1 = GameObject.Find("MeleeZoneP1");
        MeleeP2 = GameObject.Find("MeleeZoneP2");
        RangeP1 = GameObject.Find("RangeZoneP1");
        RangeP2 = GameObject.Find("RangeZoneP2");
        SiegeP1 = GameObject.Find("SiegeZoneP1");
        SiegeP2 = GameObject.Find("SiegeZoneP2");
        MeleeUpP1 = GameObject.Find("MeleeZoneUpP1");
        MeleeUpP2 = GameObject.Find("MeleeZoneUpP2");
        RangeUpP1 = GameObject.Find("RangeZoneUpP1");
        RangeUpP2 = GameObject.Find("RangeZoneUpP2");
        SiegeUpP1 = GameObject.Find("SiegeZoneUpP1");
        SiegeUpP2 = GameObject.Find("SiegeZoneUpP2");
        MeleeWheather = GameObject.Find("MeleeZoneClima");
        RangeWheather = GameObject.Find("RangeZoneClima");
        SiegeWheather = GameObject.Find("SiegeZoneClima");
    }

    //This method set cards on the field
    public void MoveToMeleeZone()
    {
        var a = GetComponent<CardDisplay>().Cardtipe;
        var x = GetComponent<CardDisplay>().Position1;
        var y = GetComponent<CardDisplay>().Position2;
        var z = GetComponent<CardDisplay>().Position3;
        if(((startParent == HandP1.transform && P1.GetComponent<Player>().IsPlaying == true && P1.GetComponent<Player>().Played == false) || (startParent == HandP2.transform && P2.GetComponent<Player>().IsPlaying == true && P2.GetComponent<Player>().Played == false)) && a == Card.CardTipe.Weather)
        {
            int WheaterInField = 0;
            foreach(Transform  card in MeleeWheather.transform)
            {
                CardDisplay rb = card.GetComponent<CardDisplay>();
                if(rb != null)
                {
                    WheaterInField++;
                }
            }
            if (WheaterInField >= WheatherLimit)
            {

            }
            else
            {
                transform.SetParent(MeleeWheather.transform, false);
                GetComponent<CardDisplay>().InField = true;
                if (startParent == HandP1.transform)
                {
                    P1.GetComponent<Player>().Played = true;
                    DeckP1.GetComponent<Draw>().CardsInHand--;
                }
                else
                {
                    P2.GetComponent<Player>().Played = true;
                    DeckP2.GetComponent<Draw>().CardsInHand--;
                }
                transform.GetComponent<CardDisplay>().CastEffect();
            }
        }
        else if(((startParent == HandP1.transform && P1.GetComponent<Player>().IsPlaying == true && P1.GetComponent<Player>().Played == false) || (startParent == HandP2.transform && P2.GetComponent<Player>().IsPlaying == true && P2.GetComponent<Player>().Played == false)) && a == Card.CardTipe.Lure)
        {
            int CardInZoneP1 = 0;
            int CardInZoneP2 = 0;
            foreach (Transform card in MeleeP1.transform)
            {
                CardDisplay rb = card.GetComponent<CardDisplay>();
                if (rb != null)
                {
                    CardInZoneP1++;
                }
            }
            foreach (Transform card in MeleeP2.transform)
            {
                CardDisplay rb = card.GetComponent<CardDisplay>();
                if (rb != null)
                {
                    CardInZoneP2++;
                }
            }
            if (startParent == HandP1.transform && CardInZoneP1 > 0)
            {
                transform.SetParent(MeleeP1.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P1.GetComponent<Player>().Played = true;
                DeckP1.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            else if (startParent == HandP2.transform && CardInZoneP2 > 0)
            {
                transform.SetParent(MeleeP2.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P2.GetComponent<Player>().Played = true;
                DeckP2.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
        }
        else if(startParent == HandP1.transform && P1.GetComponent<Player>().IsPlaying == true && P1.GetComponent<Player>().Played == false)
        {
            if ((a == Card.CardTipe.Unit && (x == Card.Position.M || y == Card.Position.M || z == Card.Position.M)) || a == Card.CardTipe.ClearWeather)
            {
                transform.SetParent(MeleeP1.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P1.GetComponent<Player>().Played = true;
                DeckP1.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            else if (a == Card.CardTipe.Upgrade)
            {
                transform.SetParent(MeleeUpP1.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P1.GetComponent<Player>().Played = true;
                DeckP1.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
        }
        else if(startParent == HandP2.transform && P2.GetComponent<Player>().IsPlaying == true && P2.GetComponent<Player>().Played == false)
        {
            if ((a == Card.CardTipe.Unit && (x == Card.Position.M || y == Card.Position.M || z == Card.Position.M)) || a == Card.CardTipe.ClearWeather)
            {
                transform.SetParent(MeleeP2.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P2.GetComponent<Player>().Played = true;
                DeckP2.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            else if (a == Card.CardTipe.Upgrade)
            { 
                transform.SetParent(MeleeUpP2.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P2.GetComponent<Player>().Played = true;
                DeckP2.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
           
        }
    }
    //This method set cards on the field
    public void MoveToRangeZone()
    {
        var a = GetComponent<CardDisplay>().Cardtipe;
        var x = GetComponent<CardDisplay>().Position1;
        var y = GetComponent<CardDisplay>().Position2;
        var z = GetComponent<CardDisplay>().Position3;
        if (((startParent == HandP1.transform && P1.GetComponent<Player>().IsPlaying == true && P1.GetComponent<Player>().Played == false) || (startParent == HandP2.transform && P2.GetComponent<Player>().IsPlaying == true && P2.GetComponent<Player>().Played == false)) && a == Card.CardTipe.Weather)
        {
            int WheaterInField = 0;
            foreach (Transform card in RangeWheather.transform)
            {
                CardDisplay rb = card.GetComponent<CardDisplay>();
                if (rb != null)
                {
                    WheaterInField++;
                }
            }
            if (WheaterInField >= WheatherLimit)
            {

            }
            else
            {
                transform.SetParent(RangeWheather.transform, false);
                GetComponent<CardDisplay>().InField = true;
                if (startParent == HandP1.transform)
                {
                    P1.GetComponent<Player>().Played = true;
                    DeckP1.GetComponent<Draw>().CardsInHand--;
                }
                else
                {
                    P2.GetComponent<Player>().Played = true;
                    DeckP2.GetComponent<Draw>().CardsInHand--;
                }
                transform.GetComponent<CardDisplay>().CastEffect();
            }
        }
        else if (startParent == HandP1.transform && P1.GetComponent<Player>().IsPlaying == true && P1.GetComponent<Player>().Played == false)
        {
            if ((a == Card.CardTipe.Unit && (x == Card.Position.R || y == Card.Position.R || z == Card.Position.R)) || a == Card.CardTipe.ClearWeather)
            {
                transform.SetParent(RangeP1.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P1.GetComponent<Player>().Played = true;
                DeckP1.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            else if (a == Card.CardTipe.Upgrade)
            {
                transform.SetParent(RangeUpP1.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P1.GetComponent<Player>().Played = true;
                DeckP1.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            
        }
        else if (((startParent == HandP1.transform && P1.GetComponent<Player>().IsPlaying == true && P1.GetComponent<Player>().Played == false) || (startParent == HandP2.transform && P2.GetComponent<Player>().IsPlaying == true && P2.GetComponent<Player>().Played == false)) && a == Card.CardTipe.Lure)
        {
            int CardInZoneP1 = 0;
            int CardInZoneP2 = 0;   
            foreach (Transform card in RangeP1.transform)
            {
                CardDisplay rb = card.GetComponent<CardDisplay>();
                if (rb != null)
                {
                    CardInZoneP1++;
                }
            }
            foreach (Transform card in RangeP2.transform)
            {
                CardDisplay rb = card.GetComponent<CardDisplay>();
                if (rb != null)
                {
                    CardInZoneP2++;
                }
            }
            if (startParent == HandP1.transform && CardInZoneP1 > 0)
            {
                transform.SetParent(RangeP1.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P1.GetComponent<Player>().Played = true;
                DeckP1.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            else if (startParent == HandP2.transform && CardInZoneP2 > 0)
            {
                transform.SetParent(RangeP2.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P2.GetComponent<Player>().Played = true;
                DeckP2.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }           
        }
        else if (startParent == HandP2.transform && P2.GetComponent<Player>().IsPlaying == true && P2.GetComponent<Player>().Played == false)
        {
            if ((a == Card.CardTipe.Unit && (x == Card.Position.R || y == Card.Position.R || z == Card.Position.R)) || a == Card.CardTipe.ClearWeather)
            {
                transform.SetParent(RangeP2.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P2.GetComponent<Player>().Played = true;
                DeckP2.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            else if (a == Card.CardTipe.Upgrade)
            {
                transform.SetParent(RangeUpP2.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P2.GetComponent<Player>().Played = true;
                DeckP2.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            
        }
    }
    //This method set cards on the field
    public void MoveToSiegeZone()
    {
        var a = GetComponent<CardDisplay>().Cardtipe;
        var x = GetComponent<CardDisplay>().Position1;
        var y = GetComponent<CardDisplay>().Position2;
        var z = GetComponent<CardDisplay>().Position3;
        if (((startParent == HandP1.transform && P1.GetComponent<Player>().IsPlaying == true && P1.GetComponent<Player>().Played == false) || (startParent == HandP2.transform && P2.GetComponent<Player>().IsPlaying == true && P2.GetComponent<Player>().Played == false)) && a == Card.CardTipe.Weather)
        {
            int WheaterInField = 0;
            foreach (Transform card in SiegeWheather.transform)
            {
                CardDisplay rb = card.GetComponent<CardDisplay>();
                if (rb != null)
                {
                    WheaterInField++;
                }
            }
            if (WheaterInField >= WheatherLimit)
            {

            }
            else
            {
                transform.SetParent(SiegeWheather.transform, false);
                GetComponent<CardDisplay>().InField = true;
                if (startParent == HandP1.transform)
                {
                    P1.GetComponent<Player>().Played = true;
                    DeckP1.GetComponent<Draw>().CardsInHand--;
                }
                else
                {
                    P2.GetComponent<Player>().Played = true;
                    DeckP2.GetComponent<Draw>().CardsInHand--;
                }
                transform.GetComponent<CardDisplay>().CastEffect();
            }
        }
        int CardInZoneP1 = 0;
        int CardInZoneP2 = 0;
        foreach (Transform card in SiegeP1.transform)
        {
            CardDisplay rb = card.GetComponent<CardDisplay>();
            if (rb != null)
            {
                CardInZoneP1++;
            }
        }
        foreach (Transform card in SiegeP2.transform)
        {
            CardDisplay rb = card.GetComponent<CardDisplay>();
            if (rb != null)
            {
                CardInZoneP2++;
            }
        }
        if (startParent == HandP1.transform && CardInZoneP1 > 0)
        {
            transform.SetParent(SiegeP1.transform, false);
            GetComponent<CardDisplay>().InField = true;
            P1.GetComponent<Player>().Played = true;
            DeckP1.GetComponent<Draw>().CardsInHand--;
            transform.GetComponent<CardDisplay>().CastEffect();
        }
        else if (startParent == HandP2.transform && CardInZoneP2 > 0)
        {
            transform.SetParent(SiegeP2.transform, false);
            GetComponent<CardDisplay>().InField = true;
            P2.GetComponent<Player>().Played = true;
            DeckP2.GetComponent<Draw>().CardsInHand--;
            transform.GetComponent<CardDisplay>().CastEffect();
        }
        else if (startParent == HandP1.transform && P1.GetComponent<Player>().IsPlaying == true && P1.GetComponent<Player>().Played == false)
        {
            if ((a == Card.CardTipe.Unit && (x == Card.Position.S || y == Card.Position.S || z == Card.Position.S)) || a == Card.CardTipe.ClearWeather)
            {
                transform.SetParent(SiegeP1.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P1.GetComponent<Player>().Played = true;
                DeckP1.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            else if (a == Card.CardTipe.Upgrade)
            {
                transform.SetParent(SiegeUpP1.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P1.GetComponent<Player>().Played = true;
                DeckP1.GetComponent<Draw>().CardsInHand--;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
           
        }
        else if (startParent == HandP2.transform && P2.GetComponent<Player>().IsPlaying == true && P2.GetComponent<Player>().Played == false)
        {
            if ((a == Card.CardTipe.Unit && (x == Card.Position.S || y == Card.Position.S || z == Card.Position.S)) || a == Card.CardTipe.ClearWeather)
            {
                transform.SetParent(SiegeP2.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P2.GetComponent<Player>().Played = true;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            else if (a == Card.CardTipe.Upgrade)
            {
                transform.SetParent(SiegeUpP2.transform, false);
                GetComponent<CardDisplay>().InField = true;
                P2.GetComponent<Player>().Played = true;
                transform.GetComponent<CardDisplay>().CastEffect();
            }
            
        }
    }


}

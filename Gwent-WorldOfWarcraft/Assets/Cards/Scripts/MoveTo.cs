using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GwentEngine;

public class MoveTo: MonoBehaviour
{
    GameObject HandP1;
    GameObject HandP2;
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
    GameObject PanelButtoms;

    Transform startParent;

    private void Start()
    {
        startParent = transform.parent;
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

    public void MoveToMeleeZone()
    {
        var a = GetComponent<CardDisplay>().Cardtipe;
        var x = GetComponent<CardDisplay>().Position1;
        var y = GetComponent<CardDisplay>().Position2;
        var z = GetComponent<CardDisplay>().Position3;
        if((startParent == HandP1.transform || startParent == HandP2.transform) && a == Card.CardTipe.Weather)
        {
            transform.SetParent(MeleeWheather.transform, false);
            GetComponent<CardDisplay>().InField = true;
        }
        else if(startParent == HandP1.transform)
        {
            if (a == Card.CardTipe.Unit && (x == Card.Position.M || y == Card.Position.M || z == Card.Position.M))
                transform.SetParent(MeleeP1.transform, false);
            else if (a == Card.CardTipe.Upgrade)
                transform.SetParent(MeleeUpP1.transform, false);
            else if (a == Card.CardTipe.Lure || a == Card.CardTipe.ClearWeather)
                transform.SetParent(MeleeP1.transform, false);
            GetComponent<CardDisplay>().InField = true;

        }
        else if(startParent ==  HandP2.transform)
        {
            if (a == Card.CardTipe.Unit && (x == Card.Position.M || y == Card.Position.M || z == Card.Position.M))
                transform.SetParent(MeleeP2.transform, false);
            else if (a == Card.CardTipe.Upgrade)
                transform.SetParent(MeleeUpP2.transform, false);
            else if (a == Card.CardTipe.Lure || a == Card.CardTipe.ClearWeather)
                transform.SetParent(MeleeP2.transform, false);
            GetComponent<CardDisplay>().InField = true;
        }
    }

    public void MoveToRangeZone()
    {
        var a = GetComponent<CardDisplay>().Cardtipe;
        var x = GetComponent<CardDisplay>().Position1;
        var y = GetComponent<CardDisplay>().Position2;
        var z = GetComponent<CardDisplay>().Position3;
        if ((startParent == HandP1.transform || startParent == HandP2.transform) && a == Card.CardTipe.Weather)
        {
            transform.SetParent(RangeWheather.transform, false);
            GetComponent<CardDisplay>().InField = true;
        }
        else if (startParent == HandP1.transform)
        {
            if (a == Card.CardTipe.Unit && (x == Card.Position.R || y == Card.Position.R || z == Card.Position.R))
                transform.SetParent(RangeP1.transform, false);
            else if (a == Card.CardTipe.Upgrade)
                transform.SetParent(RangeUpP1.transform, false);
            else if (a == Card.CardTipe.Lure || a == Card.CardTipe.ClearWeather)
                transform.SetParent(RangeP1.transform, false);
            GetComponent<CardDisplay>().InField = true;
        }
        else if (startParent == HandP2.transform)
        {
            if (a == Card.CardTipe.Unit && (x == Card.Position.R || y == Card.Position.R || z == Card.Position.R))
                transform.SetParent(RangeP2.transform, false);
            else if (a == Card.CardTipe.Upgrade)
                transform.SetParent(RangeUpP2.transform, false);
            else if (a == Card.CardTipe.Lure || a == Card.CardTipe.ClearWeather)
                transform.SetParent(RangeP2.transform, false);
            GetComponent<CardDisplay>().InField = true;
        }
    }

    public void MoveToSiegeZone()
    {
        var a = GetComponent<CardDisplay>().Cardtipe;
        var x = GetComponent<CardDisplay>().Position1;
        var y = GetComponent<CardDisplay>().Position2;
        var z = GetComponent<CardDisplay>().Position3;
        if ((startParent == HandP1.transform || startParent == HandP2.transform) && a == Card.CardTipe.Weather)
        {
            transform.SetParent(SiegeWheather.transform, false);
            GetComponent<CardDisplay>().InField = true;
        }
        else if (startParent == HandP1.transform)
        {
            if (a == Card.CardTipe.Unit && (x == Card.Position.S || y == Card.Position.S || z == Card.Position.S))
                transform.SetParent(SiegeP1.transform, false);
            else if (a == Card.CardTipe.Upgrade)
                transform.SetParent(SiegeUpP1.transform, false);
            else if (a == Card.CardTipe.Lure || a == Card.CardTipe.ClearWeather)
                transform.SetParent(SiegeP1.transform, false);
            GetComponent<CardDisplay>().InField = true;
        }
        else if (startParent == HandP2.transform)
        {
            if (a == Card.CardTipe.Unit && (x == Card.Position.S || y == Card.Position.S || z == Card.Position.S))
                transform.SetParent(SiegeP2.transform, false);
            else if (a == Card.CardTipe.Upgrade)
                transform.SetParent(SiegeUpP2.transform, false);
            else if (a == Card.CardTipe.Lure || a == Card.CardTipe.ClearWeather)
                transform.SetParent(SiegeP2.transform, false);
            GetComponent<CardDisplay>().InField = true;
        }
    }


}

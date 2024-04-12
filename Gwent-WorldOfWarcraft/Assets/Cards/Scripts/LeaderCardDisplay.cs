using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GwentEngine;
using TMPro;


public class LeaderCardDisplay : MonoBehaviour
{
    Leader card;

    public TMP_Text CardName;
    public TMP_Text CardDescription;
    public TMP_Text Positions;
    public Image ArtWork;
    bool EffectCasted1time;
    bool EffectCasted2time;
    bool EffectCasted3time;
    public bool WheaterCasted;
    string Name;
    public Card.Position Position1;
    public Card.Position Position2;
    public Card.Position Position3;
    public Leader.Effect ID;
    string Description;
    public GameObject Player;

    void Start()
    {
        WheaterCasted = false;
        card = Player.GetComponent<Player>().Leader;

        // Esto son las propiedades de la carta
        Name = card.CardName;
        Position1 = card.Position1;
        Position2 = card.Position2;
        Position3 = card.Position3;
        ID = card.ID;
        Description = card.Description;

        // Esto es lo que se muestra en la interfaz
        CardName.text = Name;
        CardDescription.text = Description;
        Positions.text = card.Positions;
        ArtWork.sprite = card.CardFront;
              
    }
   
    // This method cast Leader effect
    public void LeaderEffect()
    {
        if (Player.GetComponent<Player>().Played)
        {
            if ((!EffectCasted1time || !EffectCasted2time || !EffectCasted3time))
            {
                if (transform.parent == GameObject.Find("LeaderZone1").transform)
                {
                    if (ID == Leader.Effect.Upgrade)
                    {
                        if (Position1 == Card.Position.M || Position2 == Card.Position.M || Position3 == Card.Position.M)
                        {
                            foreach (Transform card in GameObject.Find("MeleeZoneP1").transform)
                            {
                                card.GetComponent<CardDisplay>().Upgraded = true;
                            }
                        }
                        if (Position1 == Card.Position.R || Position2 == Card.Position.R || Position3 == Card.Position.R)
                        {
                            foreach (Transform card in GameObject.Find("RangeZoneP1").transform)
                            {
                                card.GetComponent<CardDisplay>().Upgraded = true;
                            }
                        }
                        if (Position1 == Card.Position.S || Position2 == Card.Position.S || Position3 == Card.Position.S)
                        {
                            foreach (Transform card in GameObject.Find("SiegeZoneP1").transform)
                            {
                                card.GetComponent<CardDisplay>().Upgraded = true;
                            }
                        }
                    }
                    if (ID == Leader.Effect.SaveCard)
                    {
                        System.Random rand = new();
                        int count = 0;
                        int index;

                        foreach (Transform card in GameObject.Find("MeleeZoneP1").transform)
                        {
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        foreach (Transform card in GameObject.Find("RangeZoneP1").transform)
                        {
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        foreach (Transform card in GameObject.Find("SiegeZoneP1").transform)
                        {
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        index = rand.Next(0, count);
                        count = 0;
                        foreach (Transform card in GameObject.Find("MeleeZoneP1").transform)
                        {
                            if (count >= index)
                            {
                                if (count == index)
                                    card.GetComponent<CardDisplay>().BondInField = true;
                                break;
                            }
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        foreach (Transform card in GameObject.Find("RangeZoneP1").transform)
                        {
                            if (count >= index)
                            {
                                if (count == index)
                                    card.GetComponent<CardDisplay>().BondInField = true;
                                break;
                            }
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        foreach (Transform card in GameObject.Find("SiegeZoneP1").transform)
                        {
                            if (count >= index)
                            {
                                if (count == index)
                                    card.GetComponent<CardDisplay>().BondInField = true;
                                break;
                            }
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                    }

                }
                else if (transform.parent == GameObject.Find("LeaderZone2").transform)
                {
                    if (ID == Leader.Effect.Upgrade)
                    {
                        if (Position1 == Card.Position.M || Position2 == Card.Position.M || Position3 == Card.Position.M)
                        {
                            foreach (Transform card in GameObject.Find("MeleeZoneP2").transform)
                            {
                                card.GetComponent<CardDisplay>().Upgraded = true;
                            }
                        }
                        if (Position1 == Card.Position.R || Position2 == Card.Position.R || Position3 == Card.Position.R)
                        {
                            foreach (Transform card in GameObject.Find("RangeZoneP2").transform)
                            {
                                card.GetComponent<CardDisplay>().Upgraded = true;
                            }
                        }
                        if (Position1 == Card.Position.S || Position2 == Card.Position.S || Position3 == Card.Position.S)
                        {
                            foreach (Transform card in GameObject.Find("SiegeZoneP2").transform)
                            {
                                card.GetComponent<CardDisplay>().Upgraded = true;
                            }
                        }
                    }
                    if (ID == Leader.Effect.SaveCard)
                    {
                        System.Random rand = new();
                        int count = 0;
                        int index;

                        foreach (Transform card in GameObject.Find("MeleeZoneP2").transform)
                        {
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        foreach (Transform card in GameObject.Find("RangeZoneP2").transform)
                        {
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        foreach (Transform card in GameObject.Find("SiegeZoneP2").transform)
                        {
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        index = rand.Next(0, count);
                        count = 0;
                        foreach (Transform card in GameObject.Find("MeleeZoneP2").transform)
                        {
                            if (count >= index)
                            {
                                if (count == index)
                                    card.GetComponent<CardDisplay>().BondInField = true;
                                break;
                            }
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        foreach (Transform card in GameObject.Find("RangeZoneP2").transform)
                        {
                            if (count >= index)
                            {
                                if (count == index)
                                    card.GetComponent<CardDisplay>().BondInField = true;
                                break;
                            }
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                        foreach (Transform card in GameObject.Find("SiegeZoneP2").transform)
                        {
                            if (count >= index)
                            {
                                if (count == index)
                                    card.GetComponent<CardDisplay>().BondInField = true;
                                break;
                            }
                            CardDisplay rb = card.GetComponent<CardDisplay>();
                            if (rb != null)
                                count++;
                        }
                    }

                }

                if (EffectCasted1time == false)
                    EffectCasted1time = true;
                else if (EffectCasted2time == false)
                    EffectCasted2time = true;
                else
                    EffectCasted3time = true;

                Player.GetComponent<Player>().Played = true;
            }
            if (ID == Leader.Effect.Wheater)
            {
                if (Position1 == Card.Position.M || Position2 == Card.Position.M || Position3 == Card.Position.M)
                {
                    foreach (Transform card in GameObject.Find("MeleeZoneP1").transform)
                    {
                        card.GetComponent<CardDisplay>().AffectedByWeather = true;
                    }
                    foreach (Transform card in GameObject.Find("MeleeZoneP2").transform)
                    {
                        card.GetComponent<CardDisplay>().AffectedByWeather = true;
                    }
                }
                if (Position1 == Card.Position.R || Position2 == Card.Position.R || Position3 == Card.Position.R)
                {
                    foreach (Transform card in GameObject.Find("RangeZoneP1").transform)
                    {
                        card.GetComponent<CardDisplay>().AffectedByWeather = true;
                    }
                    foreach (Transform card in GameObject.Find("RangeZoneP2").transform)
                    {
                        card.GetComponent<CardDisplay>().AffectedByWeather = true;
                    }
                }
                if (Position1 == Card.Position.S || Position2 == Card.Position.S || Position3 == Card.Position.S)
                {
                    foreach (Transform card in GameObject.Find("SiegeZoneP1").transform)
                    {
                        card.GetComponent<CardDisplay>().AffectedByWeather = true;
                    }
                    foreach (Transform card in GameObject.Find("RangeZoneP2").transform)
                    {
                        card.GetComponent<CardDisplay>().AffectedByWeather = true;
                    }
                }
                if (!WheaterCasted)
                {
                    WheaterCasted = true;
                    Player.GetComponent<Player>().Played = true;
                }
            }

        }
    }
}
       
 
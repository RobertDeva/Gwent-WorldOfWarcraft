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
    bool EffectCasted;
    public bool WeatherCasted;
    public bool UpgradeCasted;
    string Name;
    public Card.Position Position1;
    public Card.Position Position2;
    public Card.Position Position3;
    public Leader.Effect ID;
    string Description;
    string EffectDescription;
    public GameObject Player;
    GameObject ZoomCardP1;
    GameObject ZoomCardP2;

    void Start()
    {
        ZoomCardP1 = GameObject.Find("ZoomCardP1");
        ZoomCardP2 = GameObject.Find("ZoomCardP2");
        WeatherCasted = false;
        card = Player.GetComponent<Player>().Leader;

        // Esto son las propiedades de la carta
        Name = card.CardName;
        Position1 = card.Position1;
        Position2 = card.Position2;
        Position3 = card.Position3;
        ID = card.ID;
        Description = card.Description;
        SetEffectDescription();

        // Esto es lo que se muestra en la interfaz
        CardName.text = Name;
        CardDescription.text = "Descripcion: " + Description +"\nEfecto: " + EffectDescription;
        Positions.text = card.Positions;
        ArtWork.sprite = card.CardFront;
              
    }
    public void Update()
    {
        if(EffectCasted || WeatherCasted)
        {
            LeaderEffect();
        }

    }

    // This method cast Leader effect
    public void LeaderEffect()
    {
        if (Player.GetComponent<Player>().Played == false)
        {
            if ((WeatherCasted  || UpgradeCasted) && EffectCasted)
            {
                if (ID == Leader.Effect.Weather && WeatherCasted)
                {
                    if (ID == Leader.Effect.Weather)
                    {
                        if (Position1 == Card.Position.M)
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
                        if (Position1 == Card.Position.R)
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
                        if (Position1 == Card.Position.S)
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
                    }

                }
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
                }
            }
            if (!EffectCasted)
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
                }          

                Player.GetComponent<Player>().Played = true;
            }
            if (ID == Leader.Effect.Weather)
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
                
                WeatherCasted = true;
                Player.GetComponent<Player>().Played = true;
            }
            EffectCasted = true;
        }
    }
    
    void SetEffectDescription()
    {
        if (ID == Leader.Effect.Upgrade)
        {
            EffectDescription = "Duplica el ataque de las Unidades de cada fila de las posiciones del Leader";
        }
        else if (ID == Leader.Effect.Weather)
        {
            EffectDescription = "Reduce el ataque de las Unidades de una fila de las posiciones del Leader a 2";
        }
    }
    public void OnHoverEnter()
    {
        GameObject P1 = GameObject.Find("LeaderZone1");
        GameObject P2 = GameObject.Find("LeaderZone2");

        if (transform.parent == P1.transform)
        {
            ZoomCardP1.GetComponent<ZoomCard>().ArtWork.sprite = card.CardFront;
            ZoomCardP1.GetComponent<ZoomCard>().Positions.text = Positions.text;
            ZoomCardP1.GetComponent<ZoomCard>().Name.text = CardName.text;
            ZoomCardP1.GetComponent<ZoomCard>().Attack.text = "  ";
            ZoomCardP1.GetComponent<ZoomCard>().CardTipe.text = "Leader"; 
            ZoomCardP1.GetComponent<ZoomCard>().Description.text = CardDescription.text;
        }
        else if(transform.parent == P2.transform)
        {
            ZoomCardP2.GetComponent<ZoomCard>().ArtWork.sprite = card.CardFront;
            ZoomCardP2.GetComponent<ZoomCard>().Positions.text = Positions.text;
            ZoomCardP2.GetComponent<ZoomCard>().Name.text = CardName.text;
            ZoomCardP2.GetComponent<ZoomCard>().Attack.text = "  ";
            ZoomCardP2.GetComponent<ZoomCard>().CardTipe.text = "Leader";
            ZoomCardP2.GetComponent<ZoomCard>().Description.text = CardDescription.text;
        }
    }
        

}
       
 
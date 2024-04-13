using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GwentEngine;

public class CardDisplay : MonoBehaviour
{
    GameObject ZoomCardP1;
    GameObject ZoomCardP2;
    public AudioSource CastingEffect;
    public Card card;

    public TMP_Text CardName;
    public TMP_Text CardDescription;
    public TMP_Text Attack;
    public TMP_Text CardTipe;
    public TMP_Text Positions;
    public Image ArtWork;

    public string Name;
    public int AttackPower;
    public Card.Faction CardFaction;
    public Card.CardTipe Cardtipe;
    public Card.Position Position1;
    public Card.Position Position2;
    public Card.Position Position3;
    public Card.Effect ID;
    public Card.Rank CardRank;
    public string Description;
    public string EffectDescription;
    
    // Start is called before the first frame update
    void Start()
    {
        ZoomCardP1 = GameObject.Find("ZoomCardP1");
        ZoomCardP2 = GameObject.Find("ZoomCardP2");

            // Son las propiedades de la carta
            Name = card.CardName;
            AttackPower = card.Attack;
            CardFaction = card.CardFaction;
            Cardtipe = card.Cardtipe;
            Position1 = card.Position1;
            Position2 = card.Position2;
            Position3 = card.Position3;
            ID = card.ID;
            CardRank = card.CardRank;
            Description = card.Description;
            SetEffectDescription();

            // Esto es lo que se muestra en la interfaz
            CardName.text = Name;
            CardDescription.text = " Descripcion: " + Description +"." + "\n Efecto: " + EffectDescription + ".";
            CardTipe.text = Cardtipe.ToString();
        if (AttackPower != 0 || Cardtipe == Card.CardTipe.Lure)
            Attack.text = AttackPower.ToString();
        else
            Attack.text = "  ";
        ArtWork.sprite = card.CardFront;
        Positions.text = card.Positions;           
    }
    public bool InField = false;
    public bool Upgraded = false;
    public bool AffectedByWeather = false;
    public bool Buffed = false;
    public bool Debuffed = false;
    public bool BondInField = false;
    public bool Selected = false;

    //This method cast Card effect
    public void CastEffect()
    {
        Invoke(nameof(Effect), 3.0f);
    }

    void Effect()
    {
        
        GameObject MeleeP1 = GameObject.Find("MeleeZoneP1");
        GameObject MeleeP2 = GameObject.Find("MeleeZoneP2");
        GameObject RangeP1 = GameObject.Find("RangeZoneP1");
        GameObject RangeP2 = GameObject.Find("RangeZoneP2");
        GameObject SiegeP1 = GameObject.Find("SiegeZoneP1");
        GameObject SiegeP2 = GameObject.Find("SiegeZoneP2");
        GameObject MeleeUpP1 = GameObject.Find("MeleeZoneUpP1");
        GameObject MeleeUpP2 = GameObject.Find("MeleeZoneUpP2");
        GameObject RangeUpP1 = GameObject.Find("RangeZoneUpP1");
        GameObject RangeUpP2 = GameObject.Find("RangeZoneUpP2");
        GameObject SiegeUpP1 = GameObject.Find("SiegeZoneUpP1");
        GameObject SiegeUpP2 = GameObject.Find("SiegeZoneUpP2");
        GameObject MeleeWheather = GameObject.Find("MeleeZoneClima");
        GameObject RangeWheather = GameObject.Find("RangeZoneClima");
        GameObject SiegeWheather = GameObject.Find("SiegeZoneClima");

      //  CastingEffect.Play();
        if ((transform.parent == MeleeWheather.transform || transform.parent == RangeWheather.transform || transform.parent == SiegeWheather.transform) && ID == Card.Effect.Weather && Cardtipe == Card.CardTipe.Weather)
        {
            if (transform.parent == MeleeWheather.transform)
            {

                foreach (Transform card in MeleeP1.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = true;
                }
                foreach (Transform card in MeleeP2.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = true;
                }

            }
            else if (transform.parent == RangeWheather.transform)
            {
                foreach (Transform card in RangeP1.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = true;
                }
                foreach (Transform card in RangeP2.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = true;
                }
            }
            else
            {
                foreach (Transform card in SiegeP1.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = true;
                }
                foreach (Transform card in SiegeP2.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = true;
                }
            }
        }
        else if ((transform.parent == MeleeUpP1.transform || transform.parent == MeleeUpP2.transform || transform.parent == RangeUpP1.transform || transform.parent == RangeUpP2.transform || transform.parent == SiegeUpP1.transform || transform.parent == SiegeUpP2.transform) && ID == Card.Effect.Upgrade && Cardtipe == Card.CardTipe.Upgrade)
        {
            if (transform.parent == MeleeUpP1.transform)
            {
                foreach (Transform card in MeleeP1.transform)
                {
                    card.GetComponent<CardDisplay>().Upgraded = true;
                }
            }
            else if (transform.parent == MeleeUpP2.transform)
            {
                foreach (Transform card in MeleeP2.transform)
                {
                    card.GetComponent<CardDisplay>().Upgraded = true;
                }
            }
            else if (transform.parent == RangeUpP1.transform)
            {
                foreach (Transform card in RangeP1.transform)
                {
                    card.GetComponent<CardDisplay>().Upgraded = true;
                }
            }
            else if (transform.parent == RangeUpP2.transform)
            {
                foreach (Transform card in RangeP2.transform)
                {
                    card.GetComponent<CardDisplay>().Upgraded = true;
                }
            }
            else if (transform.parent == SiegeUpP1.transform)
            {
                foreach (Transform card in SiegeP1.transform)
                {
                    card.GetComponent<CardDisplay>().Upgraded = true;
                }
            }
            else
            {
                foreach (Transform card in SiegeP2.transform)
                {
                    card.GetComponent<CardDisplay>().Upgraded = true;
                }
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.ClearWeather && Cardtipe == Card.CardTipe.ClearWeather)
        {
            if (transform.parent == MeleeP1.transform || transform.parent == MeleeP2.transform)
            {
                foreach (Transform card in MeleeP1.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = false;
                }
                foreach (Transform card in MeleeP2.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = false;
                }
                if (transform.parent == MeleeP1.transform)
                {
                    foreach (Transform card in MeleeWheather.transform)
                    {
                        card.GetComponent<CardDisplay>().InField = false;
                        card.SetParent(GameObject.Find("CementeryP1").transform);
                    }

                }
                else
                {
                    foreach (Transform card in MeleeWheather.transform)
                    {
                        card.GetComponent<CardDisplay>().InField = false;
                        card.SetParent(GameObject.Find("CementeryP2").transform);
                    }

                }


            }
            else if (transform.parent == RangeP1.transform || transform.parent == RangeP2.transform)
            {
                foreach (Transform card in RangeP1.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = false;
                }
                foreach (Transform card in RangeP2.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = false;
                }
                if (transform.parent == RangeP1.transform)
                {
                    foreach (Transform card in RangeWheather.transform)
                    {
                        card.GetComponent<CardDisplay>().InField = false;
                        card.SetParent(GameObject.Find("CementeryP1").transform);
                    }

                }
                else
                {
                    foreach (Transform card in RangeWheather.transform)
                    {
                        card.GetComponent<CardDisplay>().InField = false;
                        card.SetParent(GameObject.Find("CementeryP2").transform);
                    }
                }

            }
            else
            {
                foreach (Transform card in SiegeP1.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = false;
                }
                foreach (Transform card in SiegeP2.transform)
                {
                    card.GetComponent<CardDisplay>().AffectedByWeather = false;
                }
                if (transform.parent == SiegeP1.transform)
                {
                    foreach (Transform card in SiegeWheather.transform)
                    {
                        card.GetComponent<CardDisplay>().InField = false;
                        card.SetParent(GameObject.Find("CementeryP1").transform);
                    }

                }
                else
                {
                    foreach (Transform card in SiegeWheather.transform)
                    {
                        card.GetComponent<CardDisplay>().InField = false;
                        card.SetParent(GameObject.Find("CementeryP2").transform);
                    }
                }

                transform.SetParent(GameObject.Find("CementeryP2").transform);
            }

            foreach (Transform card in GameObject.Find("CementeryP1").transform)
            {
                card.gameObject.SetActive(false);
            }
            foreach (Transform card in GameObject.Find("CementeryP2").transform)
            {
                card.gameObject.SetActive(false);
            }

        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.CardUp && Cardtipe == Card.CardTipe.Unit)
        {
            foreach (Transform card in transform.parent)
            {
                card.GetComponent<CardDisplay>().Buffed = true;
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.CardDown && Cardtipe == Card.CardTipe.Unit)
        {
            foreach (Transform card in transform.parent)
            {
                card.GetComponent<CardDisplay>().Debuffed = true;
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.DestroyCard && Cardtipe == Card.CardTipe.Unit)
        {
            if (transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform)
            {
                System.Random rand = new();
                int count = 0;
                int index;

                foreach (Transform card in MeleeP2.transform)
                {
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                foreach (Transform card in RangeP2.transform)
                {
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                foreach (Transform card in SiegeP2.transform)
                {
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                index = rand.Next(0, count);
                count = 0;
                foreach (Transform card in MeleeP2.transform)
                {
                    if (count >= index)
                    {
                        if (count == index)
                        {
                            card.SetParent(GameObject.Find("CementeryP2").transform, false);
                            card.gameObject.SetActive(false);
                        }
                        break;
                    }
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                foreach (Transform card in RangeP2.transform)
                {
                    if (count >= index)
                    {
                        if (count == index)
                        {
                            card.SetParent(GameObject.Find("CementeryP2").transform, false);
                            card.gameObject.SetActive(false);
                        }
                        break;
                    }
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                foreach (Transform card in SiegeP2.transform)
                {
                    if (count >= index)
                    {
                        if (count == index)
                        {
                            card.SetParent(GameObject.Find("CementeryP2").transform, false);
                            card.gameObject.SetActive(false);
                        }
                        break;
                    }
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
            }
            else
            {
                System.Random rand = new();
                int count = 0;
                int index = 0;

                foreach (Transform card in MeleeP1.transform)
                {
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                foreach (Transform card in RangeP1.transform)
                {
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                foreach (Transform card in SiegeP1.transform)
                {
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                index = rand.Next(0, count);
                count = 0;
                foreach (Transform card in MeleeP1.transform)
                {
                    if (count >= index)
                    {
                        if (count == index)
                        {
                            card.SetParent(GameObject.Find("CementeryP1").transform, false);
                            card.gameObject.SetActive(false);
                        }
                        break;
                    }
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                foreach (Transform card in RangeP1.transform)
                {
                    if (count >= index)
                    {
                        if (count == index)
                        {
                            card.SetParent(GameObject.Find("CementeryP1").transform, false);
                            card.gameObject.SetActive(false);
                        }
                        break;
                    }
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
                foreach (Transform card in SiegeP1.transform)
                {
                    if (count >= index)
                    {
                        if (count == index)
                        {
                            card.SetParent(GameObject.Find("CementeryP1").transform, false);
                            card.gameObject.SetActive(false);
                        }
                        break;
                    }
                    CardDisplay rb = card.GetComponent<CardDisplay>();
                    if (rb != null)
                        count++;
                }
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.DrawCard && Cardtipe == Card.CardTipe.Unit)
        {
            GameObject.Find("DeckP1").GetComponent<Draw>().EffectDraw();
            GameObject.Find("DeckP2").GetComponent<Draw>().EffectDraw();
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.Lure && Cardtipe == Card.CardTipe.Lure)
        {
            if (transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || SiegeP1.transform)
            {
                foreach (Transform card in transform.parent)
                {
                    if (card.GetComponent<CardDisplay>().InField == false)
                    {
                        card.transform.SetParent(GameObject.Find("HandP1").transform, false);
                        break;
                    }
                }
                foreach (Transform card in transform.parent)
                {
                    card.GetComponent<CardDisplay>().InField = true;
                }
            }
            else
            {
                foreach (Transform card in transform.parent)
                {
                    if (card.GetComponent<CardDisplay>().InField == false)
                    {
                        card.transform.SetParent(GameObject.Find("HandP2").transform, false);
                        break;
                    }
                }
                foreach (Transform card in transform.parent)
                {
                    card.GetComponent<CardDisplay>().InField = true;
                }
            }
        }
      // Invoke(nameof(CastingEffect.Pause), 1.0f);
    }
    void SetEffectDescription()
    {
        if (ID == Card.Effect.Upgrade)
        {
            EffectDescription = "Duplica el ataque de las Unidades de una fila";
        }
        else if (ID == Card.Effect.Weather)
        {
            EffectDescription = "Reduce el ataque de las Unidades de una fila a 2";
        }
        else if (ID == Card.Effect.Lure)
        {
            EffectDescription = "Sustituye una carta en tu lado del campo y la regresa a tu mano";
        }
        else if (ID == Card.Effect.ClearWeather)
        {
            EffectDescription = "Elimina el efecto de una carta clima en la fila y destruye la carta clima";
        }
        else if(ID == Card.Effect.CardUp)
        {
            EffectDescription = "Aumenta en 2 el ataque de todas las Unidades de una fila";
        }
        else if (ID == Card.Effect.CardDown)
        {
            EffectDescription = "Disminuye en 2 el ataque de todas las Unidades de una fila";
        }
        else if (ID == Card.Effect.DestroyCard)
        {
            EffectDescription = "Destruye una carta al azar del campo contrario";
        }
        else if(ID == Card.Effect.DrawCard)
        {
            EffectDescription = "Los jugadores roban una carta";
        }
        else
        {
            EffectDescription = "No Effect";
        }
    }

    //This method show card stats on the left side of the screen
    public void OnHoverEnter()
    {
        GameObject HandP1 = GameObject.Find("HandP1");
        GameObject HandP2 = GameObject.Find("HandP2");
        GameObject MeleeP1 = GameObject.Find("MeleeZoneP1");
        GameObject MeleeP2 = GameObject.Find("MeleeZoneP2");
        GameObject RangeP1 = GameObject.Find("RangeZoneP1");
        GameObject RangeP2 = GameObject.Find("RangeZoneP2");
        GameObject SiegeP1 = GameObject.Find("SiegeZoneP1");
        GameObject SiegeP2 = GameObject.Find("SiegeZoneP2");
        GameObject MeleeWheather = GameObject.Find("MeleeZoneClima");
        GameObject RangeWheather = GameObject.Find("RangeZoneClima");
        GameObject SiegeWheather = GameObject.Find("SiegeZoneClima");

        if (transform.parent == HandP1.transform || transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform)
        {
            ZoomCardP1.GetComponent<ZoomCard>().Name.text = Name;
            ZoomCardP1.GetComponent<ZoomCard>().ArtWork.sprite = card.CardFront;
            ZoomCardP1.GetComponent<ZoomCard>().Positions.text = Positions.text;
            ZoomCardP1.GetComponent<ZoomCard>().Attack.text = Attack.text;
            ZoomCardP1.GetComponent<ZoomCard>().Description.text = CardDescription.text;
            ZoomCardP1.GetComponent<ZoomCard>().CardTipe.text = CardTipe.text;
        }
        else if (transform.parent == HandP2.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform)
        {
            ZoomCardP2.GetComponent<ZoomCard>().Name.text = Name;
            ZoomCardP2.GetComponent<ZoomCard>().ArtWork.sprite = card.CardFront;
            ZoomCardP2.GetComponent<ZoomCard>().Positions.text = Positions.text;
            ZoomCardP2.GetComponent<ZoomCard>().Attack.text = Attack.text;
            ZoomCardP2.GetComponent<ZoomCard>().Description.text = CardDescription.text;
            ZoomCardP2.GetComponent<ZoomCard>().CardTipe.text = CardTipe.text;
        }
        else if (transform.parent == MeleeWheather.transform || transform.parent == RangeWheather.transform || transform.parent == SiegeWheather.transform)
        {
            ZoomCardP1.GetComponent<ZoomCard>().Name.text = Name;
            ZoomCardP2.GetComponent<ZoomCard>().Name.text = Name;
            ZoomCardP1.GetComponent<ZoomCard>().ArtWork.sprite = card.CardFront;
            ZoomCardP2.GetComponent<ZoomCard>().ArtWork.sprite = card.CardFront;
            ZoomCardP1.GetComponent<ZoomCard>().Positions.text = Positions.text;
            ZoomCardP2.GetComponent<ZoomCard>().Positions.text = Positions.text;
            ZoomCardP1.GetComponent<ZoomCard>().Attack.text = Attack.text;
            ZoomCardP2.GetComponent<ZoomCard>().Attack.text = Attack.text;
            ZoomCardP1.GetComponent<ZoomCard>().Description.text = CardDescription.text;
            ZoomCardP2.GetComponent<ZoomCard>().Description.text = CardDescription.text;
            ZoomCardP1.GetComponent<ZoomCard>().CardTipe.text = CardTipe.text;
            ZoomCardP2.GetComponent<ZoomCard>().CardTipe.text = CardTipe.text;
        }
    }

    public void OnMouseDown()
    {
        if(InField && (transform.parent != GameObject.Find("HandP1").transform || transform.parent != GameObject.Find("HandP2").transform))
        {
            if((transform.parent == GameObject.Find("MeleeZoneP1").transform || transform.parent == GameObject.Find("RangeZoneP1").transform || transform.parent == GameObject.Find("SiegeZoneP1").transform) && GameObject.Find("Player1").GetComponent<Player>().IsPlaying && GameObject.Find("Player1").GetComponent<Player>().SustituteSelected == false)
            {
                InField = false;
                GameObject.Find("Player1").GetComponent<Player>().SustituteSelected = true;
            }
            else if((transform.parent == GameObject.Find("MeleeZoneP2").transform || transform.parent == GameObject.Find("RangeZoneP2").transform || transform.parent == GameObject.Find("SiegeZoneP2").transform) && GameObject.Find("Player2").GetComponent<Player>().IsPlaying && GameObject.Find("Player2").GetComponent<Player>().SustituteSelected == false)
            {
                InField = false;
                GameObject.Find("Player2").GetComponent<Player>().SustituteSelected = true;
            }

        }
    }
}

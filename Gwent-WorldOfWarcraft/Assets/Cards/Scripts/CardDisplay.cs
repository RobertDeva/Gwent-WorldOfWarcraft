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
    public string EffectDescripion;
    
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
            CardDescription.text = " Descripcion: " + Description +"." + "\n Efecto: " + EffectDescripion + ".";
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

    public void CastEffect()
    {

    }
    void SetEffectDescription()
    {
        if (ID == Card.Effect.Upgrade)
        {
            EffectDescripion = "Duplica el ataque de las Unidades de una fila";
        }
        else if (ID == Card.Effect.Weather)
        {
            EffectDescripion = "Reduce el ataque de las Unidades de una fila a 2";
        }
        else if (ID == Card.Effect.Lure)
        {
            EffectDescripion = "Sustituye una carta en tu lado del campo y la regresa a tu mano";
        }
        else if (ID == Card.Effect.ClearWeather)
        {
            EffectDescripion = "Elimina el efecto de una carta clima en la fila y destruye la carta clima";
        }
        else if(ID == Card.Effect.CardUp)
        {
            EffectDescripion = "Aumenta en 2 el ataque de todas las Unidades de una fila";
        }
        else if (ID == Card.Effect.CardDown)
        {
            EffectDescripion = "Disminuye en 2 el ataque de todas las Unidades de una fila";
        }
        else if (ID == Card.Effect.DestroyCard)
        {
            EffectDescripion = "Destruye una carta al azar del campo contrario";
        }
        else if(ID == Card.Effect.DrawCard)
        {
            EffectDescripion = "Los jugadores roban una carta";
        }
        else
        {
            EffectDescripion = "No Effect";
        }
    }

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

}


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
    GameObject HandP1;
    GameObject HandP2;

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


    public AudioSource CastingEffect;
    // Start is called before the first frame update
    void Start()
    {
        ZoomCardP1 = GameObject.Find("ZoomCardP1");
        ZoomCardP2 = GameObject.Find("ZoomCardP2");
        HandP1 = GameObject.Find("HandP1");
        HandP2 = GameObject.Find("HandP2");

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
        CardDescription.text = " Descripcion: " + Description + "." + "\n Efecto: " + EffectDescription + ".";
        CardTipe.text = Cardtipe.ToString();
        if (card.Attack != 0 || Cardtipe == Card.CardTipe.Lure)
            Attack.text = card.Attack.ToString();
        else
            Attack.text = "  ";
        ArtWork.sprite = card.CardFront;
        Positions.text = card.Positions;
    }
    void Update()
    {
        if ((transform.parent != GameObject.Find("HandP1") || transform.parent != GameObject.Find("HandP2")) && Cardtipe == Card.CardTipe.Weather)
        {
            CastEffect();
        }
        if ((transform.parent != GameObject.Find("HandP1") || transform.parent != GameObject.Find("HandP2")) && Cardtipe == Card.CardTipe.Upgrade)
        {
            CastEffect();
        }
    }

    public bool InField = false;
    public bool Upgraded = false;
    public bool AffectedByWeather = false;
    public bool Buffed = false;
    public bool Debuffed = false;
    public bool Selected = false;
    public bool BondInField = false;

    //This method cast Card effect
    public void CastEffect()
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
        GameObject MeleeWeather = GameObject.Find("MeleeZoneClima");
        GameObject RangeWeather = GameObject.Find("RangeZoneClima");
        GameObject SiegeWeather = GameObject.Find("SiegeZoneClima");

        CastingEffect.Play();
        if ((transform.parent == MeleeWeather.transform || transform.parent == RangeWeather.transform || transform.parent == SiegeWeather.transform) && ID == Card.Effect.Weather && Cardtipe == Card.CardTipe.Weather)
        {
            if (transform.parent == MeleeWeather.transform)
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
            else if (transform.parent == RangeWeather.transform)
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
            List<CardDisplay> cards = new();
            if (GameObject.Find("LeaderP1").GetComponent<LeaderCardDisplay>().WeatherCasted || GameObject.Find("LeaderP2").GetComponent<LeaderCardDisplay>().WeatherCasted)
            {
                GameObject.Find("LeaderP1").GetComponent<LeaderCardDisplay>().WeatherCasted = false;
                GameObject.Find("LeaderP2").GetComponent<LeaderCardDisplay>().WeatherCasted = false;
            }
            if (transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform)
            {
                foreach (Transform card in MeleeWeather.transform)
                {
                    card.SetParent(GameObject.Find("CementeryP1").transform, false);
                }
                foreach (Transform card in RangeWeather.transform)
                {
                    card.SetParent(GameObject.Find("CementeryP1").transform, false);
                }
                foreach (Transform card in SiegeWeather.transform)
                {
                    card.SetParent(GameObject.Find("CementeryP1").transform, false);
                }
                transform.SetParent(GameObject.Find("CementeryP1").transform, false);
                foreach(Transform card in GameObject.Find("CementeryP1").transform)
                {
                    card.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (Transform card in MeleeWeather.transform)
                {
                    card.SetParent(GameObject.Find("CementeryP2").transform, false);
                }
                foreach (Transform card in RangeWeather.transform)
                {
                    card.SetParent(GameObject.Find("CementeryP2").transform, false);
                }
                foreach (Transform card in SiegeWeather.transform)
                {
                    card.SetParent(GameObject.Find("CementeryP2").transform, false);
                }
                transform.SetParent(GameObject.Find("CementeryP2").transform, false);
                foreach (Transform card in GameObject.Find("CementeryP2").transform)
                {
                    card.gameObject.SetActive(false);
                }
            }
            foreach (Transform card in MeleeP1.transform)
            {
                cards.Add(card.GetComponent<CardDisplay>());
            }
            foreach (Transform card in MeleeP2.transform)
            {
                cards.Add(card.GetComponent<CardDisplay>());
            }
            foreach (Transform card in RangeP1.transform)
            {
                cards.Add(card.GetComponent<CardDisplay>());
            }
            foreach (Transform card in RangeP2.transform)
            {
                cards.Add(card.GetComponent<CardDisplay>());
            }
            foreach (Transform card in SiegeP1.transform)
            {
                cards.Add(card.GetComponent<CardDisplay>());
            }
            foreach (Transform card in SiegeP2.transform)
            {
                cards.Add(card.GetComponent<CardDisplay>());
            }
            foreach(CardDisplay card in cards)
            {
                card.AffectedByWeather = false;
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
                if (transform.parent == MeleeP1.transform)
                {
                    foreach (Transform card in MeleeP2.transform)
                    {
                        card.GetComponent<CardDisplay>().Debuffed = true;
                    }
                }
                else if (transform.parent == MeleeP2.transform)
                {
                    foreach (Transform card in MeleeP1.transform)
                    {
                        card.GetComponent<CardDisplay>().Debuffed = true;
                    }
                }
                else if (transform.parent == RangeP1.transform)
                {
                    foreach (Transform card in RangeP2.transform)
                    {
                        card.GetComponent<CardDisplay>().Debuffed = true;
                    }
                }
                else if (transform.parent == RangeP2.transform)
                {
                    foreach (Transform card in RangeP1.transform)
                    {
                        card.GetComponent<CardDisplay>().Debuffed = true;
                    }
                }
                else if (transform.parent == SiegeP1.transform)
                {
                    foreach (Transform card in SiegeP2.transform)
                    {
                        card.GetComponent<CardDisplay>().Debuffed = true;
                    }
                }
                else
                {
                    foreach (Transform card in SiegeP1.transform)
                    {
                        card.GetComponent<CardDisplay>().Debuffed = true;
                    }
                }
            }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.DestroyCard && Cardtipe == Card.CardTipe.Unit)
        {
            int x;
            List<Transform> cards = new();

            if(transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform)
            {
                foreach (Transform card in MeleeP2.transform)
                {
                    if(card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit)
                    {
                        cards.Add(card);
                    }
                }
                foreach (Transform card in RangeP2.transform)
                {
                    if (card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit)
                    {
                        cards.Add(card);
                    }
                }
                foreach (Transform card in SiegeP2.transform)
                {
                    if (card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit)
                    {
                        cards.Add(card);
                    }
                }
                x = Random.Range(0, cards.Count);
                cards[x].SetParent(GameObject.Find("CementeryP2").transform, false);
                cards[x].gameObject.SetActive(false);
            }
            else
            {
                foreach (Transform card in MeleeP1.transform)
                {
                    if (card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit)
                    {
                        cards.Add(card);
                    }
                }
                foreach (Transform card in RangeP1.transform)
                {
                    if (card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit)
                    {
                        cards.Add(card);
                    }
                }
                foreach (Transform card in SiegeP1.transform)
                {
                    if (card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit)
                    {
                        cards.Add(card);
                    }
                }
                x = Random.Range(0, cards.Count);
                cards[x].SetParent(GameObject.Find("CementeryP1").transform, false);
                cards[x].gameObject.SetActive(false);
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.DrawCard && Cardtipe == Card.CardTipe.Unit)
            {
                GameObject.Find("DeckP1").GetComponent<Draw>().EffectDraw();
                GameObject.Find("DeckP2").GetComponent<Draw>().EffectDraw();
            }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.SetPromedialAttack && Cardtipe == Card.CardTipe.Unit)
        {
            int TotalAttack = 0;
            int CardsInField = 0;
            List<Transform> cards = new();

            foreach(Transform card in MeleeP1.transform)
            {
                if(card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    TotalAttack += card.GetComponent<CardDisplay>().AttackPower;
                    CardsInField++;
                }
            }
            foreach(Transform card in MeleeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    TotalAttack += card.GetComponent<CardDisplay>().AttackPower;
                    CardsInField++;
                }
            }
            foreach(Transform card in RangeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    TotalAttack += card.GetComponent<CardDisplay>().AttackPower;
                    CardsInField++;
                }
            }
            foreach(Transform card in RangeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    TotalAttack += card.GetComponent<CardDisplay>().AttackPower;
                    CardsInField++;
                }
            }
            foreach(Transform card in SiegeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    TotalAttack += card.GetComponent<CardDisplay>().AttackPower;
                    CardsInField++;
                }
            }
            foreach(Transform card in SiegeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    TotalAttack += card.GetComponent<CardDisplay>().AttackPower;
                    CardsInField++;
                }
            }

            foreach(Transform card in cards)
            {
                card.GetComponent<CardDisplay>().AttackPower = TotalAttack / CardsInField;
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.DestroyOPCard && Cardtipe == Card.CardTipe.Unit)
        {
            int MaxPower = int.MinValue;
            List<Transform> cards = new();

            foreach (Transform card in MeleeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    if(card.GetComponent<CardDisplay>().AttackPower > MaxPower)
                    {
                        MaxPower = card.GetComponent<CardDisplay>().AttackPower;
                    }
                }
            }
            foreach (Transform card in MeleeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    if (card.GetComponent<CardDisplay>().AttackPower > MaxPower)
                    {
                        MaxPower = card.GetComponent<CardDisplay>().AttackPower;
                    }
                }
            }
            foreach (Transform card in RangeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    if (card.GetComponent<CardDisplay>().AttackPower > MaxPower)
                    {
                        MaxPower = card.GetComponent<CardDisplay>().AttackPower;
                    }
                }
            }
            foreach (Transform card in RangeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    if (card.GetComponent<CardDisplay>().AttackPower > MaxPower)
                    {
                        MaxPower = card.GetComponent<CardDisplay>().AttackPower;
                    }
                }
            }
            foreach (Transform card in SiegeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    if (card.GetComponent<CardDisplay>().AttackPower > MaxPower)
                    {
                        MaxPower = card.GetComponent<CardDisplay>().AttackPower;
                    }
                }
            }
            foreach (Transform card in SiegeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    cards.Add(card);
                    if (card.GetComponent<CardDisplay>().AttackPower > MaxPower)
                    {
                        MaxPower = card.GetComponent<CardDisplay>().AttackPower;
                    }
                }
            }
            foreach (Transform card in cards)
            {
                if(card.GetComponent<CardDisplay>().AttackPower == MaxPower && (card.parent == MeleeP1.transform || card.parent == RangeP1.transform || card.parent == SiegeP1.transform ))
                {
                    card.SetParent(GameObject.Find("CementeryP1").transform, false);
                    card.gameObject.SetActive(false);
                }
                else if(card.GetComponent<CardDisplay>().AttackPower == MaxPower && (card.parent == MeleeP2.transform || card.parent == RangeP2.transform || card.parent == SiegeP2.transform))
                {
                    card.SetParent(GameObject.Find("CementeryP2").transform, false);
                    card.gameObject.SetActive(false);
                }
                    
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.DestroyWeakCard && Cardtipe == Card.CardTipe.Unit)
        {
            int MinPower = int.MaxValue;
            List<Transform> cards = new();
            if(transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform)
            {
                foreach (Transform card in MeleeP2.transform)
                {
                    if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                    {
                        cards.Add(card);
                        if (card.GetComponent<CardDisplay>().AttackPower < MinPower)
                        {
                            MinPower = card.GetComponent<CardDisplay>().AttackPower;
                        }
                    }
                }
                foreach (Transform card in RangeP2.transform)
                {
                    if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                    {
                        cards.Add(card);
                        if (card.GetComponent<CardDisplay>().AttackPower < MinPower)
                        {
                            MinPower = card.GetComponent<CardDisplay>().AttackPower;
                        }
                    }
                }
                foreach (Transform card in SiegeP2.transform)
                {
                    if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                    {
                        cards.Add(card);
                        if (card.GetComponent<CardDisplay>().AttackPower < MinPower)
                        {
                            MinPower = card.GetComponent<CardDisplay>().AttackPower;
                        }
                    }
                }
                foreach(Transform card in cards)
                {
                    if(card.GetComponent<CardDisplay>().AttackPower == MinPower)
                    {
                        card.SetParent(GameObject.Find("CementeryP2").transform, false);
                        card.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                foreach (Transform card in MeleeP1.transform)
                {
                    if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                    {
                        cards.Add(card);
                        if (card.GetComponent<CardDisplay>().AttackPower < MinPower)
                        {
                            MinPower = card.GetComponent<CardDisplay>().AttackPower;
                        }
                    }
                }
                foreach (Transform card in RangeP1.transform)
                {
                    if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                    {
                        cards.Add(card);
                        if (card.GetComponent<CardDisplay>().AttackPower < MinPower)
                        {
                            MinPower = card.GetComponent<CardDisplay>().AttackPower;
                        }
                    }
                }
                foreach (Transform card in SiegeP1.transform)
                {
                    if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                    {
                        cards.Add(card);
                        if (card.GetComponent<CardDisplay>().AttackPower < MinPower)
                        {
                            MinPower = card.GetComponent<CardDisplay>().AttackPower;
                        }
                    }
                }
                foreach (Transform card in cards)
                {
                    if (card.GetComponent<CardDisplay>().AttackPower == MinPower)
                    {
                        card.SetParent(GameObject.Find("CementeryP1").transform, false);
                        card.gameObject.SetActive(false);
                    }
                }
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.CleanWeakLine && Cardtipe == Card.CardTipe.Unit)
        {
            int CardsInWeakLine = int.MaxValue;
            GameObject WeakLine = null;
            List<Transform> cards = new();
            int count = 0;


            foreach(Transform card in MeleeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    count++;
                }
            }
            if(count != 0 && count < CardsInWeakLine)
            {
                WeakLine = MeleeP1;
            }
            count = 0;
            foreach (Transform card in MeleeP2.transform)
            {
                
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    count++;
                }
            }
            if (count != 0 && count < CardsInWeakLine)
            {
                WeakLine = MeleeP2;
            }
            count = 0;
            foreach (Transform card in RangeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    count++;
                }
            }
            if (count != 0 && count < CardsInWeakLine)
            {
                WeakLine = RangeP1;
            }
            count = 0;
            foreach (Transform card in RangeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    count++;
                }
            }
            if (count != 0 && count < CardsInWeakLine)
            {
                WeakLine = RangeP2;
            }
            count = 0;
            foreach (Transform card in SiegeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    count++;
                }
            }
            if (count != 0 && count < CardsInWeakLine)
            {
                WeakLine = SiegeP1;
            }
            count = 0;
            foreach (Transform card in SiegeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver)
                {
                    count++;
                }
            }
            if (count != 0 && count < CardsInWeakLine)
            {
                WeakLine = SiegeP2;
            }
            foreach(Transform card in WeakLine.transform)
            {
                cards.Add(card);
            }
            if(WeakLine == MeleeP1 || WeakLine == RangeP1 || WeakLine == SiegeP1)
            {
                foreach (Transform card in cards)
                {
                    card.SetParent(GameObject.Find("CementeryP1").transform, false);
                    card.gameObject.SetActive(false);
                } 
            }
            else
            {
                foreach (Transform card in cards)
                {
                    card.SetParent(GameObject.Find("CementeryP2").transform, false);
                    card.gameObject.SetActive(false);
                }
            }
        }
        else if ((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && ID == Card.Effect.Partner && Cardtipe == Card.CardTipe.Unit)
        {
            List<Transform> cards = new();
            int count = 0;
            
            foreach(Transform card in MeleeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Name == Name)
                {
                    cards.Add(card);
                    count++;
                }
            }
            foreach (Transform card in MeleeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Name == Name)
                {
                    cards.Add(card);
                    count++;
                }
            }
            foreach (Transform card in RangeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Name == Name)
                {
                    cards.Add(card);
                    count++;
                }
            }
            foreach (Transform card in RangeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Name == Name)
                {
                    cards.Add(card);
                    count++;
                }
            }
            foreach (Transform card in SiegeP1.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Name == Name)
                {
                    cards.Add(card);
                    count++;
                }
            }
            foreach (Transform card in SiegeP2.transform)
            {
                if (card.GetComponent<CardDisplay>().Cardtipe == Card.CardTipe.Unit && card.GetComponent<CardDisplay>().CardRank == Card.Rank.Silver && card.GetComponent<CardDisplay>().Name == Name)
                {
                    cards.Add(card);
                    count++;
                }
            }
            foreach(Transform card in cards)
            {
                card.GetComponent<CardDisplay>().AttackPower = AttackPower * count;
            }
        }
    }

    void SetEffectDescription()
    {
            if (ID == Card.Effect.Upgrade)
            {
                EffectDescription = "Duplica el ataque de las Unidades de una fila";
            }
            else if (ID == Card.Effect.Weather)
            {
                EffectDescription = "Reduce el ataque de las Unidades de una fila a 1";
            }
            else if (ID == Card.Effect.Lure)
            {
                EffectDescription = "Sustituye una carta en tu lado del campo y la regresa a tu mano";
            }
            else if (ID == Card.Effect.ClearWeather)
            {
                EffectDescription = "Elimina todos las cartas climas en el campo y quita el efecto clima de las cartas lider";
            }
            else if (ID == Card.Effect.CardUp)
            {
                EffectDescription = "Aumenta en 2 el ataque de todas las Unidades de una fila";
            }
            else if (ID == Card.Effect.CardDown)
            {
                EffectDescription = "Disminuye en 2 el ataque de todas las Unidades de una fila";
            }
            else if (ID == Card.Effect.DestroyCard)
            {
                EffectDescription = "Destruye una Unidad al azar del campo contrario";
            }
            else if (ID == Card.Effect.DrawCard)
            {
                EffectDescription = "Los jugadores roban una carta";
            }
            else if(ID == Card.Effect.DestroyOPCard)
            {
                EffectDescription = "Destruye la carta con mayor poder en el campo";
            }
            else if(ID == Card.Effect.DestroyWeakCard)
            {
               EffectDescription = "Destruye la carta con menor poder del campo rival";
            }
            else if(ID == Card.Effect.SetPromedialAttack)
            {
               EffectDescription = "Calcula el promedio de poder de las unidades en el campo y iguala el poder al promedio";
            }
            else if (ID == Card.Effect.CleanWeakLine)
            {
               EffectDescription = "Destruye las unidades de la linea mas debil del campo";
            }
            else if (ID == Card.Effect.Partner)
            {
               EffectDescription = "Multiplica el ataque de cada carta igual a ella en el campo por la cantidad de cartas igual a ella en el campo";
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

            if ((transform.parent == HandP1.transform || transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform) && (GameObject.Find("Player1").GetComponent<Player>().IsPlaying || !GameObject.Find("Player1").GetComponent<Player>().CardsSwitched))
            {
                ZoomCardP1.GetComponent<ZoomCard>().Name.text = Name;
                ZoomCardP1.GetComponent<ZoomCard>().ArtWork.sprite = card.CardFront;
                ZoomCardP1.GetComponent<ZoomCard>().Positions.text = Positions.text;
                ZoomCardP1.GetComponent<ZoomCard>().Attack.text = Attack.text;
                ZoomCardP1.GetComponent<ZoomCard>().Description.text = CardDescription.text;
                ZoomCardP1.GetComponent<ZoomCard>().CardTipe.text = CardTipe.text;
            }
            else if ((transform.parent == HandP2.transform || transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && (GameObject.Find("Player2").GetComponent<Player>().IsPlaying || !GameObject.Find("Player2").GetComponent<Player>().CardsSwitched))
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

    public void OnClick()
    {
        if (!GameObject.Find("Player1").GetComponent<Player>().CardsSwitched && !GameObject.Find("Player2").GetComponent<Player>().CardsSwitched)
        {
            if (transform.parent == HandP1.transform && !GameObject.Find("Player1").GetComponent<Player>().CardsSwitched && GameObject.Find("Player1").GetComponent<Player>().Switches < 2)
            {
                GameObject.Find("Player1").GetComponent<Player>().Switches++;
                GameObject.Find("DeckP1").GetComponent<Draw>().CardsInHand--;
                GameObject.Find("DeckP1").GetComponent<Draw>().ShuffleDeck.Add(card);
                transform.SetParent(GameObject.Find("CementeryP1").transform, false);
                transform.gameObject.SetActive(false);
            }
            else if (transform.parent == HandP2.transform && !GameObject.Find("Player2").GetComponent<Player>().CardsSwitched && GameObject.Find("Player2").GetComponent<Player>().Switches < 2)
            {
                GameObject.Find("Player2").GetComponent<Player>().Switches++;
                GameObject.Find("DeckP2").GetComponent<Draw>().CardsInHand--;
                GameObject.Find("DeckP2").GetComponent<Draw>().ShuffleDeck.Add(card);
                transform.SetParent(GameObject.Find("CementeryP2").transform, false);
                transform.gameObject.SetActive(false);
            }
        }
    }
}



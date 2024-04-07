using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GwentEngine;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text CardName;
    public TMP_Text CardDescription;
    public TMP_Text Attack;
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
    
    // Start is called before the first frame update
    void Start()
    {   // Esto es lo que se muestra en la interfaz
        CardName.text = card.CardName;
        CardDescription.text = card.Description;
        Attack.text = card.Attack.ToString();
        Positions.text = card.Positions;
        ArtWork.sprite = card.CardFront;

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

    }

    public bool InField = false;
    public bool Upgraded = false;
    public bool AffectedByWeather = false;
    public bool Buffed = false;
    public bool Debuffed = false;
    public bool BondInField = false;


}

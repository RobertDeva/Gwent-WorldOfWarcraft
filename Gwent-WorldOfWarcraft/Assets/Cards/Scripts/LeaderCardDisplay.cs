using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GwentEngine;
using TMPro;


public class LeaderCardDisplay : MonoBehaviour
{
    bool start = false;
    Leader card;

    public TMP_Text CardName;
    public TMP_Text CardDescription;
    public TMP_Text Positions;
    public Image ArtWork;

    public string Name;
    public Card.Faction CardFaction;
    public Leader.CardTipe Cardtipe;
    public Card.Position Position1;
    public Card.Position Position2;
    public Card.Position Position3;
    public Leader.Effect ID;
    public Card.Rank CardRank;
    public string Description;
    public GameObject Player;
    

    // Start is called before the first frame update
    void Update()
    {
        if (start == false)
        {
            StartCard();
            // Esto es lo que se muestra en la interfaz
            CardName.text = card.CardName;
            CardDescription.text = card.Description;
            Positions.text = card.Positions;
            ArtWork.sprite = card.CardFront;

            // Son las propiedades de la carta
            Name = card.CardName;
            CardFaction = card.CardFaction;
            Cardtipe = card.Cardtipe;
            Position1 = card.Position1;
            Position2 = card.Position2;
            Position3 = card.Position3;
            ID = card.ID;
            CardRank = card.CardRank;
            Description = card.Description;
        }
      
    }
    void StartCard()
    {
        start = true;
        card = Player.GetComponent<Player>().Leader;        
    }
    public void LeaderEffect()
    {

        
    }
}
       
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GwentEngine;
using TMPro;


public class LeaderCardDisplay : MonoBehaviour
{
    bool start = false;
    public Leader card;

    public TMP_Text CardName;
    public TMP_Text CardDescription;
    public TMP_Text Positions;
    public Image ArtWork;
    public bool EffectCasted1time;
    public bool EffectCasted2time;
    string Name;
    public Card.Position Position1;
    public Card.Position Position2;
    public Card.Position Position3;
    public Leader.Effect ID;
    string Description;
    public GameObject Player;
    
    void Update()
    {
        if (start == false)
        {
            StartCard();

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
      
    }
    void StartCard()
    {
        start = true;
        card = Player.GetComponent<Player>().Leader;        
    }
    public void LeaderEffect()
    {
        if(EffectCasted1time == false && EffectCasted2time == false)
        {

        }
        
    }
}
       
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public TMP_Text CardName;
    public TMP_Text CardDescription;
    public TMP_Text Attack;
    public Image ArtWork;

    // Start is called before the first frame update
    void Start()
    {
        CardName.text = card.CardName;
        CardDescription.text = card.Description;
        Attack.text = card.Attack.ToString();
        ArtWork.sprite = card.CardFront;
    }


   
}

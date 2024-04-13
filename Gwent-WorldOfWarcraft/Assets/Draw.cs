using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GwentEngine;

public class Draw : MonoBehaviour
{
    public AudioSource DrawCards;
    public bool start = false;
    bool drawed;
    int DrawedCards = 0;
    public int CardsInHand;
    public GameObject player;
    public GameObject Card;
    public GameObject Hand;
    List<Card> Deck;
    
    void Start()
    {
        drawed = player.GetComponent<Player>().Drawed;
        Deck = Player.Shuffle(player.GetComponent<Player>().Cards);
        CardsInHand = 0;
    }
    private void Update()
    {
        if (!start)
        {
            Invoke(nameof(EffectDraw), 1.5f);
            if (CardsInHand == 10)
            {
                start = true;
            }
        }
    }

    //This method deal a card to player hand
    public void OnClick()
    {
        if (DrawedCards < Deck.Count && CardsInHand < 10 && drawed == false)
        {
            GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
            card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
            card.transform.SetParent(Hand.transform, false);
            DrawedCards++;
            CardsInHand++;
            player.GetComponent<Player>().Drawed = true;
        }
    }

    //This method deal cards to player hand at begin of  a new round or by card effect
    public void EffectDraw()
    {
        if (DrawedCards < Deck.Count && CardsInHand < 10)
        {
            GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
            card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
            card.transform.SetParent(Hand.transform, false);
            DrawedCards++;
            CardsInHand++;
        }
    }
    
    
}

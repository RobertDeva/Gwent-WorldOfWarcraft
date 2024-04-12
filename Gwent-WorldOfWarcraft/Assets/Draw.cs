using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GwentEngine;

public class Draw : MonoBehaviour
{    
    public bool start = false;
    bool drawed;
    int DrawedCards = 0;
    public int CardsInHand = 10;
    public GameObject player;
    public GameObject Card;
    public GameObject Hand;
    List<Card> Deck;
    
    void Update()
    {
        drawed = player.GetComponent<Player>().Drawed;
        if(start == false)
        {
            Deck = Player.Shuffle(player.GetComponent<Player>().Cards);
            for (int i = 0; i < 10; i++)
            {
                GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
                card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
                DrawedCards++;
                card.transform.SetParent(Hand.transform, false);
            }
            start = true;
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

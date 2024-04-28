using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GwentEngine;

public class Draw : MonoBehaviour
{
    public AudioSource Deal;
    public bool start = false;
    bool drawed;
    int DrawedCards = 0;
    public int CardsInHand = 0;
    public GameObject player;
    public GameObject Card;
    public GameObject CardVariant;
    public GameObject Hand;
    GameObject CementeryP1;
    GameObject CementeryP2;
    public List<Card> Deck;
    public List<Card> ShuffleDeck;
    void Start()
    {
        Deck = Player.Shuffle(player.GetComponent<Player>().Cards);
        CementeryP1 = GameObject.Find("CementeryP1");
        CementeryP2 = GameObject.Find("CementeryP2");
    }
    private void Update()
    {
        if (!start)
        {
            if (CardsInHand < 10)
                EffectDraw();
            else
                start = true;
        }
        drawed = player.GetComponent<Player>().Drawed;
    }

    //This method deal a card to player hand
    public void OnClick()
    {
        if (DrawedCards < Deck.Count && CardsInHand == 10 && (transform.parent == GameObject.Find("DeckZone1").transform || transform.parent == GameObject.Find("DeckZone2")) && drawed == false)
        {
            if (transform.parent == GameObject.Find("DeckZone1").transform)
            {
                GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
                card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
                card.transform.SetParent(CementeryP1.transform, false);
                DrawedCards++;
                card.SetActive(false);
            }
            else
            {
                GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
                card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
                card.transform.SetParent(CementeryP2.transform, false);
                DrawedCards++;
                card.SetActive(false);
            }
        }
        else if (DrawedCards < Deck.Count && CardsInHand < 10 && drawed == false)
        {
            GameObject card;
            Deal.Play();
            if (Deck[DrawedCards].Cardtipe == GwentEngine.Card.CardTipe.Lure)
            {
                card = Instantiate(CardVariant, new Vector2(0, 0), Quaternion.identity);
            }
            else
            {
                card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
            }
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
        if (DrawedCards < Deck.Count && CardsInHand == 10 && (transform.parent == GameObject.Find("DeckZone1").transform || transform.parent == GameObject.Find("DeckZone2")))
        {
            if (transform.parent == GameObject.Find("DeckZone1").transform)
            {
                GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
                card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
                card.transform.SetParent(CementeryP1.transform, false);
                DrawedCards++;
                card.SetActive(false);
            }
            else
            {
                GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
                card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
                card.transform.SetParent(CementeryP2.transform, false);
                DrawedCards++;
                card.SetActive(false);
            }
        }
        if (DrawedCards < Deck.Count && CardsInHand < 10)
        {
            Deal.Play();
            GameObject card;
            if (Deck[DrawedCards].Cardtipe == GwentEngine.Card.CardTipe.Lure)
            {
                card = Instantiate(CardVariant, new Vector2(0, 0), Quaternion.identity);
            }
            else
            {
                card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
            }
            card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
            card.transform.SetParent(Hand.transform, false);
            DrawedCards++;
            CardsInHand++;
        }
        
    }
    
    public void ShuffleAgain()
    {
        for (int i = 10; i < Deck.Count;)
        {
            ShuffleDeck.Add(Deck[i]);
            Deck.RemoveAt(i);
        }
        ShuffleDeck = Player.Shuffle(ShuffleDeck);
        foreach (Card card in ShuffleDeck)
        {
            Deck.Add(card);
        }
        EffectDraw();
        Invoke(nameof(EffectDraw), 0.2f);
    }
    
}

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
    public int CardsInHand;
    public GameObject player;
    public GameObject Card;
    public GameObject Hand;
    GameObject CementeryP1;
    GameObject CementeryP2;
    List<Card> Deck;
    
    void Start()
    {
        Deck = Player.Shuffle(player.GetComponent<Player>().Cards);
        CardsInHand = 0;
        CementeryP1 = GameObject.Find("CementeryP1");
        CementeryP2 = GameObject.Find("CementeryP2");
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
        drawed = player.GetComponent<Player>().Drawed;
    }

    //This method deal a card to player hand
    public void OnClick()
    {
        if (DrawedCards < Deck.Count && CardsInHand < 10 && drawed == false)
        {
            Deal.Play();
            GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
            card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
            card.transform.SetParent(Hand.transform, false);
            DrawedCards++;
            CardsInHand++;
            player.GetComponent<Player>().Drawed = true;
        }
        else if (DrawedCards < Deck.Count && CardsInHand == 10 && (transform.parent == GameObject.Find("DeckZone1").transform || transform.parent == GameObject.Find("DeckZone2")) && drawed == false)
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
    }

    //This method deal cards to player hand at begin of  a new round or by card effect
    public void EffectDraw()
    {
        if (DrawedCards < Deck.Count && CardsInHand < 10)
        {
            Deal.Play();
            GameObject card = Instantiate(Card, new Vector2(0, 0), Quaternion.identity);
            card.GetComponent<CardDisplay>().card = Deck[DrawedCards];
            card.transform.SetParent(Hand.transform, false);
            DrawedCards++;
            CardsInHand++;
        }
        else if (DrawedCards < Deck.Count && CardsInHand == 10 && (transform.parent == GameObject.Find("DeckZone1").transform || transform.parent == GameObject.Find("DeckZone2")))
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
    }
    
    
}
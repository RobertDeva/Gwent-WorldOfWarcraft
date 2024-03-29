using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using GwentEngine;

namespace GwentEngine
{ 
    public class Player : MonoBehaviour
    {
            public Card Leader { get; protected set; }
            public List<Card> Cards;
            public Stack<Card> DeckCards { get; protected set; }
            public int MeleeAttack { get; protected set; }
            public int RangeAttack { get; protected set; }
            public int Siegeattack { get; protected set; }
            public List<GameObject> Cementery = new();
            public List<GameObject> meleeCards = new();
            public List<GameObject> MeleeCards { get => meleeCards; protected set => meleeCards = value; }

            public List<GameObject> rangeCards = new();
            public List<GameObject> RangeCards { get => rangeCards; protected set => rangeCards = value; }
            public List<GameObject> siegeCards = new();
            public List<GameObject> SiegeCards { get => siegeCards; protected set => siegeCards = value; }
            public List<GameObject> meleeWeatherCard = new();
            public List<GameObject> MeleeWeatherCard { get => meleeWeatherCard; protected set => meleeWeatherCard = value; }
            public List<GameObject> meleeUpgradeCard = new();
            public List<GameObject> MeleeUpgradeCard { get => meleeUpgradeCard; protected set => meleeUpgradeCard = value; }
            public List<GameObject> rangeWeatherCard = new();
            public List<GameObject> RangeWeatherCard { get => rangeWeatherCard; protected set => rangeWeatherCard = value; }
            public List<GameObject> rangeUpgradeCard = new();
            public List<GameObject> RangeUpgradeCard { get => rangeUpgradeCard; protected set => rangeUpgradeCard = value; }
            public List<GameObject> siegeWeatherCard = new();
            public List<GameObject> SiegeWeatherCard { get => siegeWeatherCard; protected set => siegeWeatherCard = value; }
            public List<GameObject> siegeUpgradeCard = new();
            public List<GameObject> SiegeUpgradeCard { get => siegeUpgradeCard; protected set => siegeUpgradeCard = value; }
            public List<GameObject> playerHand;
            public List<GameObject> PlayerHand { get => playerHand; set => playerHand = value; }


            public void Start()
            {
              
              DeckCards = CreateDeck(Leader);
                
            }

            private Stack<Card> CreateDeck(Card leaderCard)
            {
                DeckCards = new Stack<Card>();
                List<Card> cards = new();
                foreach (Card card in Cards)
                {
                    if (card.CardFaction == leaderCard.CardFaction && card.CardTipe != Card.Cardtipe.Leader || card.CardFaction == Card.Faction.Neutral && card.CardTipe != Card.Cardtipe.Leader)
                    {
                        cards.Add(card);
                    }
                }
                cards = Shuffle(cards);
                foreach (Card card in cards)
                {
                    DeckCards.Push(card);
                }
                return DeckCards;

            }

            public List<Card> Shuffle(List<Card> cards)
            {
                System.Random random = new();
                List<Card> list = new();

                while (cards.Count > 0)
                {
                    int index = random.Next(0, cards.Count);
                    list.Add(cards[index]);
                    cards.RemoveAt(index);
                }
                return list;
            }
    }
}
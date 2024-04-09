using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GwentEngine
{
    [CreateAssetMenu(fileName = "New LeaderCard", menuName = "LeaderCard")]
    public class Leader : ScriptableObject
    {
        public string CardName;
        public Card.Faction CardFaction;
        public CardTipe Cardtipe = CardTipe.Leader;
        public Card.Position Position1;
        public Card.Position Position2;
        public Card.Position Position3;
        public Card.Rank CardRank = Card.Rank.Special;
        public Effect ID;
        public string Description;
        public string Positions;
        public Sprite CardFront;

        public enum Effect
        {
            SaveCard,
            Upgrade,
            Clima,
            Victory
        }
            
        public enum CardTipe
        {
            Leader
        }
            
            
    }
}
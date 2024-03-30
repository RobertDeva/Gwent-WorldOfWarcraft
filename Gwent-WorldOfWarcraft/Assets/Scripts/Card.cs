using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GwentEngine
{ 
 public class Card : MonoBehaviour
 {   // Campos y Propiedades de la clase Card
        public new string name;
    public string Name { get => name; }
        public Image front;
    public Image Front { get => front;}
        public UnitCardtipe rango; 
    public UnitCardtipe Rango { get => rango;}
        public Faction cardFaction;
    public Faction CardFaction { get => cardFaction; }
        public int attack;
    public int Attack { get => attack;}
        public Cardtipe cardTipe;
    public Cardtipe CardTipe { get => cardTipe; }
        public List<Position> positions;
    public List<Position> Positions { get => positions; }
        public EffectId id;
    public EffectId Id { get => id; }
    private bool melee = false;
    public bool Melee { get => melee; set => melee = value; }
    private bool siege = false;
    public bool Siege { get => siege; set => siege = value; }
    private bool range = false;
    public bool Range { get => range; set => range = value; }
    private bool climatic = false;
    public bool Climatic { get => climatic; protected set => climatic = value; }
    public bool isUpgraded = false;
    public bool IsUpgraded { get => isUpgraded; set => isUpgraded = value; }
    public bool isUp = false;
    public bool IsUp { get => isUp; set => isUp = value; }
    public bool isDown = false;
    public bool IsDown { get => isDown; set => isDown = value; }

    public bool isClimatized = false;
    public bool IsClimatized { get => isClimatized; set => isClimatized = value;}
    public bool IsOnField = false;

    // Son las facciones que puede tener la clase Card
    public enum Faction
    {
        The_Horde,
        The_Alliance,
        Neutral
    }

    // Son los tipos que puede tener la clase Card
    public enum Cardtipe
    {
        Leader,
        Unit,
        Wheater,
        Upgrade,
        WheaterClear,
        Lure
    }
    public enum Position
    {
        M,
        R,
        S,
    }

    public enum UnitCardtipe
    {
            Gold,
            Silver,
            Special
    }


    public enum EffectId
    {
        Clima,
        Aumento,
        Victoria,
        SetClima,
        Señuelo,
        DrawCard,
        CardUp,
        CardDown,
        DestroyCard,
        CancelClima,
        SaveCard,
        NoEffect,
    }

    public string SetEffect()
    {
        if (Id == EffectId.Clima && CardTipe == Cardtipe.Wheater)
        {
             return "Disminuye el ataque a la mitad de las cartas de una fila especifica del jugador y el adversario";
        }
        else if (Id == EffectId.Aumento && (CardTipe == Cardtipe.Upgrade || CardTipe == Cardtipe.Leader))
        {
             return "Aumenta el ataque al doble de las cartas de una fila especifica del jugador";
        }
        else if (Id == EffectId.Victoria && CardTipe == Cardtipe.Leader)
        {
             return "En caso de empate esta carta se puede utilizar como condicion de victoria";
        }
        else if (Id == EffectId.Señuelo && CardTipe == Cardtipe.Lure)
        {
             return "El jugador puede sustituir una carta del campo con esta y traer la carta devuelta al su mano";
        }
        else if (Id == EffectId.SetClima && CardTipe == Cardtipe.Unit)
        {
             return "El jugador puede colocar una carta de clima de su mano";
        }
        else if (Id == EffectId.CardUp && CardTipe == Cardtipe.Unit)
        {
             return "Duplica el ataque de la carta con el ataque mas bajo en una fila especifica del jugador";
        }
        else if (Id == EffectId.DestroyCard && CardTipe == Cardtipe.Unit)
        {
             return "Destruye una carta del campo del adversario";
        }
        else if (Id == EffectId.DrawCard && CardTipe == Cardtipe.Unit)
        {
             return "Los dos jugadores roban una carta";
        }
        else if (Id == EffectId.CancelClima && CardTipe == Cardtipe.WheaterClear)
        {
             return "Niega el efecto de una carta clima  en una fila especifica del campo y se van al cementerio tanto la carta clima negada como esta";
        }
        else if(Id == EffectId.SaveCard && CardTipe == Cardtipe.Leader)
        {
             return "Al final de la ronda una carta al azar tu campo no sera enviada  ";
        }
       
             return  "No Effect";
        
    }
    public void CastEffect()
    {
         if(CardTipe == Cardtipe.Leader)
         {

         }
         else if(CardTipe == Cardtipe.Unit)
         {

         }
         else if(CardTipe == Cardtipe.Wheater)
         {

         }
         else if(CardTipe == Cardtipe.WheaterClear)
         {

         }
         else if(CardTipe == Cardtipe.Lure)
         {

         }
         else if(CardTipe == Cardtipe.Upgrade)
         {

         }
    }


 }

}
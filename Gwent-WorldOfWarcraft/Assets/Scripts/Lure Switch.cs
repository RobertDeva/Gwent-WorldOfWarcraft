using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureSwitch : MonoBehaviour
{
    GameObject HandP1;
    GameObject HandP2;
    GameObject MeleeP1;
    GameObject MeleeP2;
    GameObject RangeP1;
    GameObject RangeP2;
    GameObject SiegeP1;
    GameObject SiegeP2;
    GameObject Player1;
    GameObject Player2;
    Transform StartParent;
    // Start is called before the first frame update
    void Start()
    {
        HandP1 = GameObject.Find("HandP1");
        HandP2 = GameObject.Find("HandP2");
        MeleeP1 = GameObject.Find("MeleeZoneP1");
        MeleeP2 = GameObject.Find("MeleeZoneP2");
        RangeP1 = GameObject.Find("RangeZoneP1");
        RangeP2 = GameObject.Find("RangeZoneP2");
        SiegeP1 = GameObject.Find("SiegeZoneP1");
        SiegeP2 = GameObject.Find("SiegeZoneP2");
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
    }

    public void OnClick()
    {
        if((transform.parent == MeleeP1.transform || transform.parent == RangeP1.transform || transform.parent == SiegeP1.transform) && transform.GetComponent<CardDisplay>().Cardtipe == GwentEngine.Card.CardTipe.Unit && transform.GetComponent<CardDisplay>().CardRank == GwentEngine.Card.Rank.Silver && Player1.GetComponent<Player>().IsPlaying && Player1.GetComponent<Player>().UsingLure  && !Player1.GetComponent<Player>().Played)
        {
            StartParent = transform.parent;
            Player1.GetComponent<Player>().Played = true;
            Player1.GetComponent<Player>().UsingLure = false;
            foreach(Transform x in HandP1.transform)
            {
                if(x.GetComponent<CardDisplay>().Selected)
                {
                    x.SetParent(StartParent, false);
                    break;
                }
            }
            transform.SetParent(HandP1.transform, false);
        }
        else if ((transform.parent == MeleeP2.transform || transform.parent == RangeP2.transform || transform.parent == SiegeP2.transform) && transform.GetComponent<CardDisplay>().Cardtipe == GwentEngine.Card.CardTipe.Unit && transform.GetComponent<CardDisplay>().CardRank == GwentEngine.Card.Rank.Silver && Player2.GetComponent<Player>().IsPlaying && Player2.GetComponent<Player>().UsingLure && !Player2.GetComponent<Player>().Played)
        {
            StartParent = transform.parent;            
            Player2.GetComponent<Player>().Played = true;
            Player2.GetComponent<Player>().UsingLure = false;
            foreach (Transform x in HandP2.transform)
            {
                if (x.GetComponent<CardDisplay>().Selected)
                {
                    x.SetParent(StartParent, false);
                    break;
                }
            }
            transform.SetParent(HandP2.transform, false);
        }
    }

}

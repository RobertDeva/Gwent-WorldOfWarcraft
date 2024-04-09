using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    GameObject GameTracker;

    public GameObject Player;
    public GameObject Card;
    public GameObject Hand;
    // Start is called before the first frame update
    private void Start()
    {
        GameTracker = GameObject.Find("GameTracker");
    }

    // Update is called once per frame
    private void Update()
    {
        if(GameTracker.GetComponent<GameTracker>().start == true && Player.GetComponent<Player>().StartPlay == false)
        {
            for (int i = 0; i < 10; i++)
            {
                Invoke(nameof(OnClick), 3.0f);
            }
            Player.GetComponent<Player>().StartPlay = true;
        }
    }
    public void OnClick()
    {
        int CardsInHand = 0;
        foreach(Transform child in Hand.transform)
        {
            CardDisplay carta = child.GetComponent<CardDisplay>();
            if(carta != null)
            {
                CardsInHand++;
            }
        }
        if ((Player.GetComponent<Player>().StartPlay  == false||(Player.GetComponent<Player>().Drawed == false && Player.GetComponent<Player>().IsPlaying == true)) && CardsInHand < 10 )
        {   System.Random random = new System.Random();
            GameObject card = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            card.GetComponent<CardDisplay>().card = Player.GetComponent<Player>().cards[random.Next(0,24)];
            card.transform.SetParent(Hand.transform, false);
            Player.GetComponent<Player>().Drawed = true;
        }
    }
}

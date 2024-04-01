using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject Card;
    public GameObject Hand;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            GameObject card = Instantiate(Card, new Vector3(0,0,0), Quaternion.identity);
            card.transform.SetParent(Hand.transform,false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        
        GameObject card = Instantiate(Card, new Vector3(0,0,0), Quaternion.identity);
        card.transform.SetParent(Hand.transform,false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonTrasparency : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHoverEnter()
    {
        Color color = transform.GetComponent<Image>().color;
        color.a = 1.0f;
        transform.GetComponent<Image>().color = color;
    }

    public void OnHoverExit()
    {
        Color color = transform.GetComponent<Image>().color;
        color.a = 0.0f;
        transform.GetComponent<Image>().color = color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToCreatioMenu : MonoBehaviour
{
    Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    public void BackToCreationMenu()
    {
        transform.position = StartPosition;
        transform.gameObject.SetActive(false);
    }
}

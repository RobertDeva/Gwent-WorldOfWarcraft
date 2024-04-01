using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
   private bool IsDragging = false;

    private void Start()
    {
      
    }
    private void Update()
    {
        if (IsDragging)
        {
          transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }
    }

    public void StartDrag()
    {
        IsDragging = true;
    }
    public void EndDrag()
    {
        IsDragging = false;
    }

}
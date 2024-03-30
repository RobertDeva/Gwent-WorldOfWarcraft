using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject HandP1;
    public GameObject HandP2;
    public GameObject MeleeZoneP1;
    public GameObject MeleeZoneUpP1;
    public GameObject MeleeZoneClimaP1;
    public GameObject MeleeZoneP2;
    public GameObject MeleeZoneUpP2;
    public GameObject MeleeZoneClimaP2;
    public GameObject RangeZoneP1;
    public GameObject RangeZoneUpP1;
    public GameObject RangeZoneClimaP1;
    public GameObject RangeZoneP2;
    public GameObject RangeZoneUpP2;
    public GameObject RangeZoneClimaP2;
    public GameObject SiegeZoneP1;
    public GameObject SiegeZoneUpP1;
    public GameObject SiegeZoneClimaP1;
    public GameObject SiegeZoneP2;
    public GameObject SiegeZoneUpP2;
    public GameObject SiegeZoneClimaP2;

    public GameObject startParent;
    public Vector3 startPosition;
    private bool isOverDropZone;
    public bool isDragging = false;
    public GameObject dropzone;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dropzone = collision.gameObject;
        if (startParent == HandP1.transform && (dropzone.transform == MeleeZoneP1.transform || dropzone.transform == RangeZoneP1.transform || dropzone.transform == SiegeZoneP1.transform))
        {
            isOverDropZone = true;
        }
        else if (startParent == HandP2.transform && (dropzone.transform == MeleeZoneP2.transform || dropzone.transform == RangeZoneP2.transform || dropzone.transform == SiegeZoneP2.transform ))
        {
            isOverDropZone = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropzone = null;
    }

    private void Start()
    {
        Canvas = GameObject.Find("MainCanvas");
        HandP1 = GameObject.Find("HandP1");
        HandP2 = GameObject.Find("HandP2");
        MeleeZoneP1 = GameObject.Find("MeleeZoneP1");
        MeleeZoneP2 = GameObject.Find("MeleeZoneP2");
        MeleeZoneUpP1 = GameObject.Find("MeleeZoneUpP1");
        MeleeZoneUpP2 = GameObject.Find("MeleeZoneUpP2");
        MeleeZoneClimaP1 = GameObject.Find("MeleeZoneClimaP1");
        MeleeZoneClimaP2 = GameObject.Find("MeleeZoneClimaP2");
        RangeZoneP1 = GameObject.Find("RangeZoneP1");
        RangeZoneP2 = GameObject.Find("RangeZoneP2");
        RangeZoneUpP1 = GameObject.Find("RangeZoneUpP1");
        RangeZoneUpP2 = GameObject.Find("RangeZoneUpP2");
        RangeZoneClimaP1 = GameObject.Find("RangeZoneClimaP1");
        RangeZoneClimaP2 = GameObject.Find("RangeZoneClimmaP2");
        SiegeZoneP1 = GameObject.Find("SiegeZoneP1");
        SiegeZoneP2 = GameObject.Find("SiegeZoneP2");
        SiegeZoneUpP1 = GameObject.Find("SiegeZoneUpP1");
        SiegeZoneUpP2 = GameObject.Find("SiegeZoneUpP2");
        SiegeZoneClimaP1 = GameObject.Find("SiegeZoneClimaP1");
        SiegeZoneClimaP2 = GameObject.Find("SiegeZoneClimaP2");
    }

        // Update is called once per frame

        void Update()
        {
            if (isDragging)
            {
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                transform.SetParent(Canvas.transform, true);
            }
        }


        public void StartDrag()
        {
           if (startParent == HandP1 || startParent == HandP2)
           { 
            startPosition = transform.position;
            isDragging = true;
           }  
            
        }

        public void EndDrag()
        {
            isDragging = false;
            if (isOverDropZone)
            {
                transform.SetParent(dropzone.transform, false);
            }
            else
            {
                transform.position = startPosition;
                transform.SetParent(startParent.transform, false);
            }
        }
}
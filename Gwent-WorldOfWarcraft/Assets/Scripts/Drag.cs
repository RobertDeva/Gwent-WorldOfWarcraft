using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Hand1;
    public GameObject Hand2;
    public GameObject MeleeZone1;
    public GameObject MeleeZoneUp1;
    public GameObject MeleeZoneClima1;
    public GameObject MeleeZone2;
    public GameObject MeleeZoneUp2;
    public GameObject MeleeZoneClima2;
    public GameObject RangeZone1;
    public GameObject RangeZoneUp1;
    public GameObject RangeZoneClima1;
    public GameObject RangeZone2;
    public GameObject RangeZoneUp2;
    public GameObject RangeZoneClima2;
    public GameObject SiegeZone1;
    public GameObject SiegeZoneUp1;
    public GameObject SiegeZoneClima1;
    public GameObject SiegeZone2;
    public GameObject SiegeZoneUp2;
    public GameObject SiegeZoneClima2;

    public GameObject startParent;
    public Vector2 startPosition;
    private bool isOverDropZone;
    public bool isDragging = false;
    public GameObject dropzone;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        dropzone = collision.gameObject;
        if (startParent == Hand1.transform && (dropzone.transform == MeleeZone1.transform || dropzone.transform == RangeZone1.transform))
        {
            isOverDropZone = true;
        }
        else if (startParent == Hand2.transform && (dropzone.transform == MeleeZone2.transform || dropzone.transform == RangeZone2.transform || dropzone.transform == SiegeZone2.transform ))
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
        Hand1 = GameObject.Find("Hand1");
        Hand2 = GameObject.Find("Hand2");
        MeleeZone1 = GameObject.Find("MeleeZone1");
        MeleeZone2 = GameObject.Find("MeleeZone2");
        MeleeZoneUp1 = GameObject.Find("MeleeZoneUp1");
        MeleeZoneUp2 = GameObject.Find("MeleeZoneUp2");
        MeleeZoneClima1 = GameObject.Find("MeleeZoneClima1");
        MeleeZoneClima2 = GameObject.Find("MeleeZoneClima2");
        RangeZone1 = GameObject.Find("RangeZone1");
        RangeZone2 = GameObject.Find("RangeZone2");
        RangeZoneUp1 = GameObject.Find("RangeZoneUp1");
        RangeZoneUp2 = GameObject.Find("RangeZoneUp2");
        RangeZoneClima1 = GameObject.Find("RangeZoneClima1");
        RangeZoneClima2 = GameObject.Find("RangeZoneClimma2");
        SiegeZone1 = GameObject.Find("SiegeZone1");
        SiegeZone2 = GameObject.Find("SiegeZone2");
        SiegeZoneUp1 = GameObject.Find("SiegeZoneUp1");
        SiegeZoneUp2 = GameObject.Find("SiegeZoneUp2");
        SiegeZoneClima1 = GameObject.Find("SiegeZoneClima1");
        SiegeZoneClima2 = GameObject.Find("SiegeZoneClima2");
    }

        // Update is called once per frame

        void Update()
        {
            if (isDragging)
            {
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
        }


        public void StartDrag()
        {
            startParent = transform.parent.gameObject;
            if (startParent == Hand1.transform || startParent == Hand2.transform)
            {
                isDragging = true;
                startPosition = transform.position;
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
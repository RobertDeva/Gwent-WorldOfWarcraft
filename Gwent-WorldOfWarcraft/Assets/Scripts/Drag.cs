using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   bool IsOverDropZone = false;
    
    Transform startParent;
    GameObject MeleeZoneP1;
    GameObject MeleeZoneP2;
    GameObject RangeZoneP1;
    GameObject RangeZoneP2;
    GameObject SiegeZoneP1;
    GameObject SiegeZoneP2;
    GameObject HandP1;
    GameObject HandP2;
    GameObject MeleeZoneUpP1;
    GameObject MeleeZoneUpP2;
    GameObject RangeZoneUpP1;
    GameObject RangeZoneUpP2;
    GameObject SiegeZoneUpP1;
    GameObject SiegeZoneUpP2;
    GameObject MeleeZoneClimaP1;
    GameObject MeleeZoneClimaP2;
    GameObject RangeZoneClimaP1;
    GameObject RangeZoneClimaP2;
    GameObject SiegeZoneClimaP1;
    GameObject SiegeZoneClimaP2;
    GameObject dropzone;

    public void OnBeginDrag(PointerEventData eventData)
    {    
        startParent = transform.parent;
        if(startParent == HandP1.transform || startParent == HandP2.transform)
        transform.SetParent(transform.parent.parent.parent, false);
    }
    public void OnDrag(PointerEventData eventData)
    {
       
        this.transform.position = eventData.position;
        transform.SetParent(transform.parent.parent.parent, true);

    }
    public void OnEndDrag(PointerEventData eventData)
    { 
        if (IsOverDropZone)
        {
            if(startParent == HandP1.transform && (dropzone.transform == MeleeZoneP1.transform || dropzone.transform == RangeZoneP1.transform || dropzone.transform == SiegeZoneP1.transform))
            {
                this.transform.SetParent(dropzone.transform, false);
            }
            else if(startParent == HandP2.transform && (dropzone.transform == MeleeZoneP2.transform || dropzone.transform == RangeZoneP2.transform || dropzone.transform == SiegeZoneP2.transform))
            {

            }
            else
            {
                this.transform.SetParent(startParent, false);
            }
        }
        else
        {
            this.transform.SetParent(startParent,false);
        }
       
    }
    void Start()
    {
       
        HandP1 = GameObject.Find("HandP1");
        HandP2 = GameObject.Find("HandP2");
        MeleeZoneP1 = GameObject.Find("MeleeZoneP1");
        MeleeZoneP2 = GameObject.Find("MeleeZoneP2");
        RangeZoneP1 = GameObject.Find("RangeZoneP1");
        RangeZoneP2 = GameObject.Find("RangeZoneP2");
        SiegeZoneP1 = GameObject.Find("SiegeZoneP1");
        SiegeZoneP2 = GameObject.Find("SiegeZoneP2");
        MeleeZoneUpP1 = GameObject.Find("MeleeZoneUpP1");
        MeleeZoneUpP2 = GameObject.Find("MeleeZoneUpP2");
        RangeZoneUpP1 = GameObject.Find("RangeZoneUpP1");
        RangeZoneUpP2 = GameObject.Find("RangeZoneUpP2");
        SiegeZoneUpP1 = GameObject.Find("SiegeZoneUpP1");
        SiegeZoneUpP2 = GameObject.Find("SiegeZoneUpP2");
        MeleeZoneClimaP1 = GameObject.Find("MeleeZoneClimaP1");
        MeleeZoneClimaP2 = GameObject.Find("MeleeZoneClimaP2");
        RangeZoneClimaP1 = GameObject.Find("RangeZoneClimaP1");
        RangeZoneClimaP2 = GameObject.Find("RangeZoneClimaP2");
        SiegeZoneClimaP1 = GameObject.Find("SiegeZoneClimaP1");
        SiegeZoneClimaP2 = GameObject.Find("SiegeZoneClimaP2");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsOverDropZone = true;
        dropzone = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsOverDropZone = false;
        dropzone = null;
    }
}
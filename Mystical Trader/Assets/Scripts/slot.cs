using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {

       GameObject dropped = eventData.pointerDrag;
        
        if (dropped.tag == "Plant"){
            
            pickup pickup = dropped.GetComponent<pickup>();
            pickup.parentAfterDrag = transform;
        }

        
        if (dropped.tag =="EmptyPot"){
            
            emptyPot pickup = dropped.GetComponent<emptyPot>();
            pickup.parentAfterDrag = transform;
            Debug.Log("Tag: " + dropped.tag);
        }


    }
}
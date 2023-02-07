using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class mixingSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {

       GameObject dropped = eventData.pointerDrag;
        Debug.Log("Mixing slot draggable landed");
        if (dropped.tag == "Plant"){
            
            pickup pickup = dropped.GetComponent<pickup>();
            pickup.parentAfterDrag = transform;
        }

        
        if (dropped.tag =="SpawnNew"){
               Debug.Log("spawn new time");

        }


    }
}

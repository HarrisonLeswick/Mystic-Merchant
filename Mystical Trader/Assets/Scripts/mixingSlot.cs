using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class mixingSlot : MonoBehaviour, IDropHandler
{
    public GameObject emptyPotPrefab;
    private GameObject emptyPot;

    public void OnDrop(PointerEventData eventData) {

       GameObject dropped = eventData.pointerDrag;       
        if (dropped.tag == "Plant"){
            
            pickup pickup = dropped.GetComponent<pickup>();
            pickup.parentAfterDrag = transform;
        }

        
        if (dropped.tag =="SpawnNew"){
               Instantiate(emptyPotPrefab, new Vector3(90.0f, -65, 0), Quaternion.identity);
                emptyPot = GameObject.Find("/EmptyPot(Clone)");
                emptyPot.transform.SetParent(gameObject.transform);


        }


    }
}

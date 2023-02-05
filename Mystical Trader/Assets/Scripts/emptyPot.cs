using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class emptyPot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image; 
    [HideInInspector] public Transform parentAfterDrag;
    
    public void OnBeginDrag(PointerEventData evemtData){
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root); // becomes a child off the UI 
        transform.SetAsLastSibling(); //becomes the last child this makes it so it is the closest to the camera and wont pass under things
        image.raycastTarget = false; //no ray on drag
   }

  public void OnDrag(PointerEventData evemtData){

      transform.position = Input.mousePosition; //Lets the object stay under the mouse using events 
  }

  public void OnEndDrag(PointerEventData evemtData){
   Debug.Log("Drag end");
   transform.SetParent(parentAfterDrag);
   image.raycastTarget = true; //ray comes back

  Debug.Log("Parent: " + parentAfterDrag);


   if (transform.parent != null && transform.parent.tag == "Sun"){ //Finds out if the plant is on the counter the mixing spot or
    Debug.Log("Sun");
   }
      if (transform.parent != null && transform.parent.tag == "Counter"){
    Debug.Log("Counter");
   }
         if (transform.parent != null && transform.parent.tag == "Mixing"){
    Debug.Log("Mixing");
   }
            if (transform.parent != null && transform.parent.tag == "Inventory"){
    Debug.Log("Inventory");
   }
               if (transform.parent != null && transform.parent.tag == "Cutting Board"){
    Debug.Log("Cutting Board");
   }
               if (transform.parent != null && transform.parent.tag == "Pot"){
    Debug.Log("Pot");
   }

  }
}


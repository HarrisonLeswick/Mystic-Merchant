using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class wateringCan : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
 public GameObject waterObj;

    public void OnBeginDrag(PointerEventData evemtData){
    waterObj.transform.SetParent(transform.root); // becomes a child off the UI 
    waterObj.transform.SetAsLastSibling(); //becomes the last child this makes it so it is the closest to the camera and wont pass under things

   }

  public void OnDrag(PointerEventData evemtData){

      waterObj.transform.position = Input.mousePosition; //Lets the object stay under the mouse using events 
  }

  public void OnEndDrag(PointerEventData evemtData){

    // waterObj.transform.position = basePosition;

  }
}

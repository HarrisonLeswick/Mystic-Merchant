using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class seeds : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Vector3 basePosition; 
    public GameObject seed;


   public void OnBeginDrag(PointerEventData evemtData){
    seed.transform.SetParent(transform.root); // becomes a child off the UI 
    seed.transform.SetAsLastSibling(); //becomes the last child this makes it so it is the closest to the camera and wont pass under things

   }

  public void OnDrag(PointerEventData evemtData){

      seed.transform.position = Input.mousePosition; //Lets the object stay under the mouse using events 
  }

  public void OnEndDrag(PointerEventData evemtData){
     seed.transform.position = basePosition;
  }
}

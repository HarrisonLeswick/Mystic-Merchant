using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class potss : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
 public GameObject potDraggable;
public Vector3 basePosition; 
 
 private void Start() { 
        basePosition = potDraggable.transform.position;
    }

    public void OnBeginDrag(PointerEventData evemtData){
       potDraggable.transform.SetParent(transform.root); // becomes a child off the UI 
       potDraggable.transform.SetAsLastSibling(); //becomes the last child this makes it so it is the closest to the camera and wont pass under things
    }

  public void OnDrag(PointerEventData evemtData){
        potDraggable.transform.position = Input.mousePosition;
       
  }

  public void OnEndDrag(PointerEventData evemtData){
     potDraggable.transform.position = basePosition;

  }
}
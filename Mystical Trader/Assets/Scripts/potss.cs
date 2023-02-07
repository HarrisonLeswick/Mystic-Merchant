using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class potss : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
 public GameObject emptyPotPrefab;
public Vector3 basePosition; 
 
 private void Start() { 
        basePosition = emptyPotPrefab.transform.position;
    }

    public void OnBeginDrag(PointerEventData evemtData){
       emptyPotPrefab.transform.SetParent(transform.root); // becomes a child off the UI 
       emptyPotPrefab.transform.SetAsLastSibling(); //becomes the last child this makes it so it is the closest to the camera and wont pass under things
    }

  public void OnDrag(PointerEventData evemtData){
        emptyPotPrefab.transform.position = Input.mousePosition;
       
  }

  public void OnEndDrag(PointerEventData evemtData){
     emptyPotPrefab.transform.position = basePosition;

  }
}
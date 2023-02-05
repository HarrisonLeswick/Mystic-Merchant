using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dirtDrawer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image; 
    public Image dirtyImage;
    public GameObject dirt;
    public Sprite closed;
    public Sprite open;
    public Vector3 basePosition; 

    private void Start() { 
        basePosition = dirt.transform.position;
    }



 public void OnPointerEnter(PointerEventData eventData)
   {

      gameObject.GetComponent<Image>().sprite = open;
   }

     
public void OnPointerExit(PointerEventData eventData)
   {
      gameObject.GetComponent<Image>().sprite = closed;
   }

   public void OnBeginDrag(PointerEventData evemtData){
    dirt.transform.SetParent(transform.root); // becomes a child off the UI 
    dirt.transform.SetAsLastSibling(); //becomes the last child this makes it so it is the closest to the camera and wont pass under things
    dirtyImage.raycastTarget = false; //no ray on drag
   }

  public void OnDrag(PointerEventData evemtData){

      dirt.transform.position = Input.mousePosition; //Lets the object stay under the mouse using events 
  }

  public void OnEndDrag(PointerEventData evemtData){

   dirtyImage.raycastTarget = true; //ray comes back
     dirt.transform.position = basePosition;

  }
}

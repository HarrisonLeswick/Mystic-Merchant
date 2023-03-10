using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class emptyPot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

  public GameObject BlueSeedPrefab;
  public GameObject GoldSeedPrefab;
  public GameObject GreenSeedPrefab;
  public GameObject OrangeSeedPrefab;
  public GameObject PinkSeedPrefab;
  public GameObject RedSeedPrefab;

    public Image image;
    public Sprite fullPot;
    private GameObject parent;
    public GameObject dirt;
    private int dirtLevel;
    private bool full = false;


    [HideInInspector] public Transform parentAfterDrag;

 
  public void Awake(){
    dirt = GameObject.Find("Dirt Drawer");
  }

  public void OnDrop(PointerEventData eventData) {
   GameObject drop = eventData.pointerDrag;;
   if (drop == dirt){
      if (dirtLevel <3){
      dirtLevel++;
      Debug.Log("Dirt: " + dirtLevel);
      }
      if(dirtLevel ==  3){
        image.sprite = fullPot;
        full = true;
      }

   }
   if (dirtLevel == 3 && drop.tag == "BlueSeed"){ //Finds out if the plant is on the counter the mixing spot or
    Debug.Log("BlueSeed");
    Instantiate(BlueSeedPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    Destroy(this.gameObject);
   }
    if (dirtLevel == 3 && drop.tag == "GoldSeed"){
    Instantiate(GoldSeedPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    Debug.Log("GoldSeed");
    Destroy(this.gameObject);
   }
    if (dirtLevel == 3 && drop.tag == "GreenSeed"){
    Instantiate(GreenSeedPrefab, new Vector3(0, 0, 0), Quaternion.identity);   
    Debug.Log("GreenSeed");
    Destroy(this.gameObject);
   }
    if (dirtLevel == 3 && drop.tag == "OrangeSeed"){
    Instantiate(OrangeSeedPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    Debug.Log("OrangeSeed");
    Destroy(this.gameObject);
   }
    if (dirtLevel == 3 && drop.tag == "PinkSeed"){
    Instantiate(PinkSeedPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    Debug.Log("PinkSeed");
    Destroy(this.gameObject);
   }
    if (dirtLevel == 3 && drop.tag == "RedSeed"){
    Instantiate(RedSeedPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    Debug.Log("RedSeed");
    Destroy(this.gameObject);
   }
   
   
}


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

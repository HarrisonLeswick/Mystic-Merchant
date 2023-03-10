using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class pickup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
   //used to know where the object will spawn
   private GameObject mixingSpot;

    public GameObject plant;
    public GameObject root;
    public GameObject water;
    public Image image; 

    //used to change the image when you look inside
    public Sprite closed;
    public Sprite open;

   public Vector3 waterHiding;
   public Image wetImage;
   public Sprite regular;
   public Sprite pour;
   private bool pouring = false;
   private float pourTimer = 0.0f;

   private bool isChopped = false;
    private bool isOpen = false;
    [HideInInspector] public Transform parentAfterDrag;

   //Variables for having the plant rejuvenate in the sun
   private float sunTimer = 0.0f;
   public float sunLevel = 3.0f;
   public float sunInterval = 5.0f;
   public float sunDecayTimer = 0.0f;

   public float waterLevel = 3.0f;
   public float waterDecayTimer = 0.0f;


   
   public float lifeLvl = 0.0f;
   public float lifeInterval = 15.0f;
   public float lifeTimer = 0.0f;

    public bool alive = true;
    public bool adult = false;

   public float timer = 0.0f;
   public float decayInterval;

private void Awake(){
   //dont touch i this idk why it needs this

   sunLevel = 3;
   mixingSpot = GameObject.Find("Mixing Slot");
   water = GameObject.Find("Watering can Draggable");
   wetImage = water.GetComponent<Image>();
   transform.SetParent(mixingSpot.transform);
}
      
private void Update() {
   //timer that lets the water level decay
   waterDecayTimer += Time.deltaTime;
   lifeTimer += Time.deltaTime;
   timer += Time.deltaTime;

   //timer that lets the water level decay
   if(transform.parent.tag != "Sun"){
      sunDecayTimer += Time.deltaTime;
   }

   //lowers the sun level after 15 seconds
   if (sunDecayTimer >= decayInterval){
      sunDecayTimer = 0;
      if(sunLevel > 0 && !adult){
         sunLevel--;
      }
      if(sunLevel <= 0)
         {
               Debug.Log("Plant is dead");
               alive=false;
               Destroy(plant);
               // plant is dead
         }
      //Debug.Log("Sun: " + sunLevel);
   }
   //lowers the water level after 15 seconds
   if (waterDecayTimer >= decayInterval){
      waterDecayTimer = 0;
      if(waterLevel > 0 && !adult){
         waterLevel--;
      }
      if(waterLevel <= 0)
         {
               Debug.Log("Plant is dead");
               alive = false;
               Destroy(plant);
         }
      //Debug.Log("Water: " + waterLevel);
   }

   if(pouring == true){
      pourTimer += Time.deltaTime;
   }
   if(pourTimer >= 0.5){
      pouring = false;
      pourTimer = 0;
      wetImage.sprite = regular;
      water.transform.position = waterHiding;
   }

   //checks if the the plant is in the sun and to up the sun level
   if(transform.parent.tag == "Sun"){
   sunTimer += Time.deltaTime;
   }
  
  //rejuvenate the plant after it has been here a while
   if (sunTimer >= sunInterval) {
      sunTimer = 0;
      if(sunLevel < 3){
         sunLevel++;
      }
      //Debug.Log(sunLevel);
   }

   // this adds to the life interval increasing time it takes depending on how well the plant is taken care of
   if (timer >= 1){
      timer = 0;
      // Debug.Log(lifeInterval + "  Tv2 " + (((waterLevel+1)/4) + (sunLevel+1)/4));
      // Debug.Log((((waterLevel+1)/4) + ((sunLevel+1)/4)));
      lifeInterval +=  (2 - (((waterLevel+1)/4) + (sunLevel+1)/4));
   }

   // this checks to see how to grow
   if (lifeTimer >= ((lifeLvl + 1) * lifeInterval)){
      lifeTimer = 0;
      if(lifeLvl < 2)
      {
         lifeLvl++;
         //call plant to level up with level
         plant.GetComponent<plant>().grow(lifeLvl);
      }

        if(lifeLvl == 2)
            {
               isChopped = true;
                adult = true;
                Debug.Log("Plant is grown");
            }
      //Debug.Log("Life Level =");
      //Debug.Log (lifeLvl);
   }

}



public void OnDrop(PointerEventData eventData) {

   GameObject waterCan = eventData.pointerDrag;;
   if (waterCan.tag == "Water"){
      Debug.Log("Watered plant");
      if (alive && waterLevel <3){
      waterLevel++;
      }
      wetImage.sprite = pour;
      pouring = true;
   }
}

  
public void OnPointerEnter(PointerEventData eventData)
   {
      if (alive && !isChopped){
         gameObject.GetComponent<Image>().sprite = open;
         root.GetComponent<root>().rootChange(waterLevel, sunLevel);
         isOpen = true;
      }
   }

     
public void OnPointerExit(PointerEventData eventData)
   {
      gameObject.GetComponent<Image>().sprite = closed;
      root.GetComponent<root>().rootHide();
      isOpen = false;
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
      if (lifeLvl == 2)
      {
         Color c = image.color;
         c.a = 0;
         // destroys the object and adds the corresponding plant
         gameObject.GetComponent<Image> ().color = c;
      }
   
   }
   
   if (transform.parent != null && transform.parent.tag == "Pot"){
    Debug.Log("Pot");
   }

  }
}

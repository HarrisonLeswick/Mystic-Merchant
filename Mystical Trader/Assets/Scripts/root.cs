using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class root : MonoBehaviour
{
    //Gets image to change root or value
    public Image image; 
    public List<Sprite> rootList;
    private float spriteNum;

     //function for changeing roots also sets alpha to 1
     public void rootChange(float waterLvl, float sunLvl){
        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1.0f;
        image.color = tempColor;

        spriteNum = (waterLvl + (3*(sunLvl-1))- 1);
        //Debug.Log("Full: " + spriteNum + " Water: " + waterLvl + " Sun: " + sunLvl);
        if(spriteNum >= 0){
            gameObject.GetComponent<Image>().sprite = rootList[(int)spriteNum];
        }

    }
    
    //gets rid of alpba value
    public void rootHide(){
          image = GetComponent<Image>();
          var tempColor = image.color;
          tempColor.a = 0.0f;
          image.color = tempColor;

    }

     
}

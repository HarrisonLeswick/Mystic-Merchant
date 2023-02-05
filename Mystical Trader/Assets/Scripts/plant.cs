using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class plant : MonoBehaviour
{
    public Image image;
    public List<Sprite> plantList;

    public void grow(float lifeLvl){
    gameObject.GetComponent<Image>().sprite = plantList[(int)lifeLvl];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class potionMachine : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image; 
    public Sprite closed;
    public Sprite open;


    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = open;
    }

     
    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = closed;
    }
}

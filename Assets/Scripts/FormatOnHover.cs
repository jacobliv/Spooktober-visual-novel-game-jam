using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FormatOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public TextMeshProUGUI text;
    public Image           arrow;


    public void OnPointerEnter(PointerEventData eventData) {
        StartCoroutine(FormatOn());
    }
    
    private IEnumerator FormatOn() {
        float third = 1/3f;
        for (int i = 0; i < 3; i++) {
            Color color = arrow.color;
            color.a += third; 
            arrow.color = color;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void OnPointerExit(PointerEventData eventData) {

        StartCoroutine(FormatOff());

    }
    
    private IEnumerator FormatOff() {
        float third = 1/3f;
        for (int i = 0; i < 3; i++) {
            Color color = arrow.color;
            color.a -= third; 
            arrow.color = color;
            yield return new WaitForSeconds(.1f);
        }
    }
}

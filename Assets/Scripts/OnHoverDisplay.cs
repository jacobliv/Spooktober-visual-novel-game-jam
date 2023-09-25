using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverDisplay : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    public GameObject panel;
    public void OnPointerEnter(PointerEventData eventData) {
        panel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        panel.SetActive(false);

    }
}

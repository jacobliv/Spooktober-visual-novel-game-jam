using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAdjustPanelWidth : MonoBehaviour {
    public RectTransform current;
    public RectTransform characterName;
    public RectTransform title;


    // Update is called once per frame
    void Update() {
        current.sizeDelta = new Vector2(characterName.sizeDelta.x+title.sizeDelta.x+32, current.sizeDelta.y);

    }
}

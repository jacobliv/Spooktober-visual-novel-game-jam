using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeTextBox : MonoBehaviour{
    public RectTransform rect;
    public float         large;
    public float         small;
    private void Awake() {
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, large);
    }

    private void OnDisable() {
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, small);
    }
}

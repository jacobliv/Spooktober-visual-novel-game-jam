using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour {
    public float fullWidth;

    public RectTransform main;

    public  RectTransform line;
    [Range(0,1f)]
    public  float         value;
    private float         oldValue;
    private void OnValidate() {
        if (Mathf.Abs(value - oldValue) > .05f) {
            oldValue = value;
            UpdateSize();
        }
    }

    public void IncrementBar(float val) {
        value += val;
        UpdateSize();
    }
    private void UpdateSize() {
        main.sizeDelta = new Vector2(value*fullWidth, main.rect.height);
        line.anchoredPosition = new Vector2(value*fullWidth, 0);

    }
}

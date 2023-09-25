using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWhenValuesEdited : MonoBehaviour {

    public Button          button;
    public Image           image;
    public Color           swapColor;
    public TextMeshProUGUI text;

    public void Awake() {
        text.color=Color.black;
        image.color=Color.white;
    }

    public void ValueChanged() {
        button.enabled = true;
        image.color=swapColor;
        text.color=Color.white;
    }

}

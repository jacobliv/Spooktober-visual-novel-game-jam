using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitializeHistoryItem : MonoBehaviour {
    public  TextMeshProUGUI name;
    public  TextMeshProUGUI text;
    public  TextMeshProUGUI under;
    public Color           color;

    private void Start() {
        color = new Color(0.2352941f,0.8627452f,0.08627451f,1f);
    }

    public void Initialize(string nameValue, string textValue) {
        name.text = nameValue.Equals("")?"----------":nameValue +": \t";
        
        text.text = textValue;
        if (nameValue.Equals("")) {
            under.text = "----------";
            name.color=Color.white;
            under.color = Color.white;
        }
        else {
            under.text = "";
        }

    }
}

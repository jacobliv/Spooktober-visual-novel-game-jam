using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitializeHistoryItem : MonoBehaviour {
    public TextMeshProUGUI name;
    public TextMeshProUGUI text;
    public void Initialize(string nameValue, string textValue) {
        name.text = nameValue.Equals("")?"":nameValue +": \t";
        text.text = textValue;
    }
}

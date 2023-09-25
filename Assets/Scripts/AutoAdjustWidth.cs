using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoAdjustWidth : MonoBehaviour {
    public TextMeshProUGUI text;
    public RectTransform   size;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        TMP_TextInfo textInfo = text.GetTextInfo(text.text);
        float textWidth = textInfo.textComponent.GetPreferredValues().x;
        size.sizeDelta = new Vector2(textWidth, size.sizeDelta.y);

    }
}

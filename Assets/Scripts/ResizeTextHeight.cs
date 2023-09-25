using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResizeTextHeight : MonoBehaviour {
    public RectTransform rectTransform;

    public  TextMeshProUGUI text;
    private TMP_TextInfo    textInfo;
    private string          previousText;
    private int             previousOverflowLines;

    private void Start() {
        textInfo = text.textInfo;

        previousText = text.text;
        previousOverflowLines = 0;
    }

    private void Update() {
        if (text.text != previousText) {

            Debug.Log("Number of overflow lines changed: " + textInfo.lineCount);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, textInfo.lineCount * 27);
            

            previousText = text.text;
        }
    }

}

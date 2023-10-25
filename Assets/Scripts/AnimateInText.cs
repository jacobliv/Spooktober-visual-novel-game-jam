using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimateInText : MonoBehaviour {
    public  TMP_Text  textMeshPro;
    public float     delayBetweenCharacters = 0.001f;
    private Coroutine _animate;

    private void OnValidate() {
        if (Application.isPlaying) {
            AnimateText();
        }
    }

    private void Start() {
        AnimateText();
    }

    public void AnimateText() {
        if(_animate != null) {
            StopCoroutine(_animate);
        }   
        // _animate=StartCoroutine(AnimateTextCoroutine());
        // textMeshPro.maxVisibleCharacters = textMeshPro.text.Length;

    }

    private IEnumerator AnimateTextCoroutine() {
        textMeshPro.maxVisibleCharacters = 0;

        yield return null; // Wait for one frame before starting the animation


        for (int i = 0; i < textMeshPro.text.Length; i++) {
            textMeshPro.maxVisibleCharacters += 1;
            yield return new WaitForSecondsRealtime(delayBetweenCharacters);
        }

        // Ensure all characters are visible at the end of the animation
        textMeshPro.maxVisibleCharacters = textMeshPro.text.Length;
    }
}

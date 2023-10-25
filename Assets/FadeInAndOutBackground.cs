using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInAndOutBackground : MonoBehaviour {
    public Image image;
    public Color defaultColor;
    public float lerpDuration = .2f;

    public void FadeIn() {
        StartCoroutine(FadeInCoroutine(defaultColor));
    }
    
    public void FadeOut() {
        StartCoroutine(FadeInCoroutine(Color.clear, true));
    }
    
    private IEnumerator FadeInCoroutine(Color targetColor,bool disable=false) {
        float elapsedTime = 0f;
        Color initialColor = image.color;
        yield return new WaitForSeconds(2);
        while (elapsedTime < lerpDuration) {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / lerpDuration);
            Color imageAlphaColor = Color.Lerp(initialColor, targetColor, t);
            image.color = imageAlphaColor;
            yield return null;
        }

        // Ensure the image reaches the fully opaque target color
        image.color = targetColor;

    }
    
}

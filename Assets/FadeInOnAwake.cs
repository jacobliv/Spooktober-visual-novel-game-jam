using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOnAwake : MonoBehaviour {
    public Image image;
    public float lerpDuration=.1f;
    private void Awake() {
        
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn() {
        float elapsedTime = 0f;
        Color initialColor = image.color;
        Color targetColor = Color.white;
        yield return new WaitForSeconds(2);
        while (elapsedTime < lerpDuration)
        {
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    public  Image image;
    public Color defaultColor;



    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        float lerpDuration = 0.1f;
        Color initialColor = image.color;
        Color targetColor = defaultColor;

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


    public void OnPointerEnter(PointerEventData eventData) {
        StartCoroutine(FadeIn());
    }

    public void OnPointerExit(PointerEventData eventData) {
        StartCoroutine(FadeOut());
    }
    
    
    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        float lerpDuration = 0.1f;
        Color initialColor = image.color;
        Color clearColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f); // Transparent color

        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / lerpDuration);
            Color imageAlphaColor = Color.Lerp(initialColor, clearColor, t);
            image.color = imageAlphaColor;
            yield return null;
        }

        // Ensure the image reaches the fully transparent color
        image.color = clearColor;
    }

}

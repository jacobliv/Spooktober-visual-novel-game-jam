using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextChoiceHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    public TextMeshProUGUI text;
    public int             smallFontSize;
    public int             largeFontSize;
    public GameObject      image;

    private Coroutine fontSizeChangeCoroutine;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cancel any existing font size change coroutine to prevent conflicts
        if (fontSizeChangeCoroutine != null)
        {
            StopCoroutine(fontSizeChangeCoroutine);
        }

        // Start the coroutine to smoothly increase font size
        fontSizeChangeCoroutine = StartCoroutine(LerpFontSize(text.fontSize, largeFontSize, 0.1f));
        image.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Cancel any existing font size change coroutine to prevent conflicts
        if (fontSizeChangeCoroutine != null)
        {
            StopCoroutine(fontSizeChangeCoroutine);
        }

        // Start the coroutine to smoothly decrease font size
        fontSizeChangeCoroutine = StartCoroutine(LerpFontSize(text.fontSize, smallFontSize, 0.1f));
        image.SetActive(false);
    }

    private IEnumerator LerpFontSize(float startSize, float endSize, float duration) {
        float time = 0f;

        while (time < duration) {
            float t = time / duration;
            text.fontSize = Mathf.Lerp(startSize, endSize, t);
            time += Time.deltaTime;
            yield return null;
        }

        // Ensure that the font size is set to the final value after the loop ends
        text.fontSize = endSize;
    }
}
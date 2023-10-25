using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutAndDisable : MonoBehaviour {
    public Image image1;
    public Image image2;
    public float lerpDuration=.1f;

    public void Fade() {
        StartCoroutine(FadeOut());
    }
    
    private IEnumerator FadeOut() {
        float elapsedTime = 0f;
        Color initialColor1 = image1.color;
        Color initialColor2 = image2.color;

        Color clearColor1 = new Color(initialColor1.r, initialColor1.g, initialColor1.b, 0f); // Transparent color
        Color clearColor2 = new Color(initialColor2.r, initialColor2.g, initialColor2.b, 0f); // Transparent color

        while (elapsedTime < lerpDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / lerpDuration);
            Color imageAlphaColor1 = Color.Lerp(initialColor1, clearColor1, t);
            image1.color = imageAlphaColor1;
            Color imageAlphaColor2 = Color.Lerp(initialColor1, clearColor1, t);
            image2.color = imageAlphaColor2;
            yield return null;
        }

        // Ensure the image reaches the fully transparent color
        image1.color = clearColor1;
        image2.color = clearColor2;
        gameObject.SetActive(false);

    }
}

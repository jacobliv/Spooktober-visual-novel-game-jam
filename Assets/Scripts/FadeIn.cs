using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    public Image image;
    public float duration;

    public void FadeInFunc() {
        StartCoroutine(FormatOn());
    }
    
    
    private IEnumerator FormatOn() {
        float elapsedTime = 0f;
        float lerpDuration = duration; // Total time in seconds for lerping (3 iterations * 0.1 seconds per iteration)

        while (elapsedTime < lerpDuration) {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / lerpDuration); // Clamp t between 0 and 1
            if (image != null) {
                Color imageLerpColor = Color.Lerp(Color.clear, Color.white, t);
                image.color = imageLerpColor;
            }

            
            yield return null;
        }

        // Ensure the color is set to the final hover color after the lerp is completed
        if (image != null) {
            image.color = Color.white;
        }

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlubberHover : MonoBehaviour
{
    public  float         hoverHeight = 10.0f;
    public  float         hoverSpeed  = 1.0f;
    public  RectTransform rect;
    private Vector2       initialPosition;
    private float         elapsedTime = 0.0f;
    private bool          isHovering  = false;
    public int           numberOfBobs;

    private void Awake()
    {
        initialPosition = rect.anchoredPosition;
    }

    public void StartHover()
    {
        if (!isHovering) {
            isHovering = true;
            StartCoroutine(HoverCoroutine());
        }
    }



    private IEnumerator HoverCoroutine() {
        Vector2 targetPosition = new Vector2(initialPosition.x,initialPosition.y+hoverHeight);

        while (Mathf.Abs(rect.anchoredPosition.y-targetPosition.y)>.05f) {
            rect.anchoredPosition = SlowInLerp(rect.anchoredPosition, targetPosition, Time.deltaTime * hoverSpeed*2);
            yield return null;

        }

        for (int i = 0; i < numberOfBobs; i++) {
            yield return UpDown();
        }
        rect.anchoredPosition = targetPosition;
        
        targetPosition = initialPosition;
        while (Mathf.Abs(rect.anchoredPosition.y-initialPosition.y)>.05f) {
            rect.anchoredPosition = SlowInLerp(rect.anchoredPosition, targetPosition, Time.deltaTime * hoverSpeed*2);
            yield return null;

        }
        rect.anchoredPosition = targetPosition;
        isHovering = false;
        yield return null;
    }

    public IEnumerator UpDown() {
        Vector2 targetPosition = new Vector2(initialPosition.x,rect.anchoredPosition.y+5);

        while (Mathf.Abs(rect.anchoredPosition.y-targetPosition.y)>.05f) {
            rect.anchoredPosition = SlowInLerp(rect.anchoredPosition, targetPosition, Time.deltaTime * hoverSpeed);
            yield return null;

        }
        rect.anchoredPosition = targetPosition;
        targetPosition = new Vector2(initialPosition.x,rect.anchoredPosition.y-5);

        while (Mathf.Abs(rect.anchoredPosition.y-targetPosition.y)>.05f) {
            rect.anchoredPosition = SlowInLerp(rect.anchoredPosition, targetPosition, Time.deltaTime * hoverSpeed);
            yield return null;

        }
        rect.anchoredPosition = targetPosition;
    }
    
    public static float SlowInEasing(float t)
    {
        return Mathf.Sqrt(t)/3;
    }

    // Slow-in lerp function
    public static Vector3 SlowInLerp(Vector3 start, Vector3 end, float t)
    {
        float easedT = SlowInEasing(t);
        return Vector3.Lerp(start, end, easedT);
    }
}

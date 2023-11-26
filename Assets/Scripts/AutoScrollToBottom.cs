using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScrollToBottom : MonoBehaviour {
    public ScrollRect scrollRect;
    public void ScrollToBottom() {
        StartCoroutine(Scroll());
    }

    public IEnumerator Scroll() {
        yield return new WaitForSeconds(.25f);
        scrollRect.normalizedPosition = new Vector2(0, 0);

    }
}

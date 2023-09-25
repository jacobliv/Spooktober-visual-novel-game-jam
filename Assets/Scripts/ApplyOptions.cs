using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyOptions : MonoBehaviour {
    public ToggleMenu toggleOptions;
    void Start() {
        toggleOptions.transitionAction += ApplyOption;
    }

    public void ApplyOption() {
        Debug.LogWarning("Options still need to be applied");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GetInitialValues : MonoBehaviour {
    public                   AudioMixer                mixer;
    [SerializeField] private List<string>              parameterNames;
    private                  Dictionary<string, float> values = new();
    public                   List<Slider>              sliders;

    private void Awake() {
        foreach (string parameterName in parameterNames) {
            mixer.GetFloat(parameterName, out var val);
            Debug.Log($"Saving {parameterName}:{val}");
            values[parameterName] = val;
        }
    }

    public void SetInitial() {
        int i = 0;
        foreach (var (key, value) in values) {
            Debug.Log($"Using {key}: {value}");
            mixer.SetFloat(key, value);
            sliders[i++].value=Mathf.Pow(10, value / 76.8f) / 1.2f;
        }
    }
}

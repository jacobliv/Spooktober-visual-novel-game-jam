using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsAudioController : MonoBehaviour {
    public TextMeshProUGUI percentage;
    public Slider          slider;
    void Start() {
        percentage.text = (int)(slider.value * 100)+"%";
    }

    // Update is called once per frame
    void Update() {
        percentage.text = (int)(slider.value * 100)+"%";

    }
}

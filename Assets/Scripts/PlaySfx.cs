using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySfx : MonoBehaviour {
    public Button      button;
    public AudioSource audioSource;
    void Start() {
        button.onClick.AddListener(()=>audioSource.Play());
    }


}

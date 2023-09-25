using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SwitchOnClick : MonoBehaviour {
    public UnityEvent onClick;
    void Update() {
        if (Input.anyKey) {
            SceneManager.LoadScene("StartMenu");
            onClick.Invoke(); 
        }

    }
}

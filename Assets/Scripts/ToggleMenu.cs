using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMenu : MonoBehaviour {
    public             Button     button;
    public GameObject currentMenu;
    public GameObject nextMenu;
    public delegate void TransitionAction();

    public TransitionAction transitionAction;
    void Start() {
        button.onClick.AddListener(Call);
        Debug.Log("Starting " + name);
    }

    private void Call() {
        Debug.Log("Calling!");
        transitionAction?.Invoke();
        if(currentMenu  != null) {
            currentMenu.SetActive(false);
        }        
        if(nextMenu != null) {
            
            nextMenu.SetActive(true);
        }    
    }
}

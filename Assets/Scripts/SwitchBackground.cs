using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwitchBackground : MonoBehaviour {
    public GameObject       background;
    public List<GameObject> toDisable;
    public GameObject       newBackground;
    public List<GameObject> toEnable;
    public NarrativeManager       flubberGone;

    public void RunSwitchBackground() {
        toDisable.ForEach((g)=>g.SetActive(false));
        background.SetActive(false);
        newBackground.SetActive(true);
        foreach (GameObject o in toEnable) {

            o.SetActive(true);
            
        }

    }
}

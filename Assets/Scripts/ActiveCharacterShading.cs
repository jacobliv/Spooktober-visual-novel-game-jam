using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCharacterShading : MonoBehaviour {

    public GameObject threeLeft;
    public GameObject threeCenter;
    public GameObject threeRight;
    public GameObject twoLeft;
    public GameObject twoRight;
    public GameObject oneCenter;
    public Color      shadeColor;
    
    // public void AddCharacter()
    
    public void MakeActive(NarrationItem narrationItem) {
        ClearCurrent();
        // speaking character has Character object
        // character positioning is based off of art1 art2 art3
        // we need to store all the art phases in the characters so we can check
        
        if (narrationItem.characterArt1.Equals(Art.NA)) return;
        if (!narrationItem.characterArt1.Equals(Art.NA) &&
        !narrationItem.characterArt2.Equals(Art.NA) &&
        !narrationItem.characterArt3.Equals(Art.NA)) {
            if (!IsCurrentCharacter(narrationItem,threeLeft.transform)) {
                Darken(threeLeft.transform);
            }
            if (!IsCurrentCharacter(narrationItem,threeCenter.transform)) {
                Darken(threeCenter.transform);
            }
            if (!IsCurrentCharacter(narrationItem,threeRight.transform)) {
                Darken(threeRight.transform);
            }

            return;
        }
        if (!narrationItem.characterArt1.Equals(Art.NA) &&
            !narrationItem.characterArt2.Equals(Art.NA) &&
            narrationItem.characterArt3.Equals(Art.NA)) {
            if (!IsCurrentCharacter(narrationItem,twoLeft.transform)) {
                Darken(twoLeft.transform);
            }
            if (!IsCurrentCharacter(narrationItem,twoRight.transform)) {
                Darken(twoRight.transform);
            }
        }
    }

    private bool IsCurrentCharacter(NarrationItem narrationItem, Transform parent) {
        return narrationItem.character.arts.Contains((Art)Enum.Parse(typeof(Art), parent.GetChild(0).name));
    }

    private void Darken(Transform parent) {
        if(parent.childCount == 0) return;
        if (parent.childCount == 1) {
            parent.transform.GetChild(0).GetComponent<Image>().color=shadeColor;
        }
        else {
            parent.transform.GetChild(1).GetComponent<Image>().color=shadeColor;
        }

    }

    private void ClearCurrent() {
        ClearChild(threeLeft.transform);
        ClearChild(threeCenter.transform);
        ClearChild(threeRight.transform);
        ClearChild(twoLeft.transform);
        ClearChild(twoRight.transform);
        ClearChild(oneCenter.transform);
    }

    private void ClearChild(Transform parent) {
        if(parent.childCount ==0) return;
        parent.transform.GetChild(0).GetComponent<Image>().color=Color.white;

    }
}

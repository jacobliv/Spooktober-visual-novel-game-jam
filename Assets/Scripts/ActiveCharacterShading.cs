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
    private Color      extraDark = new Color(.08f,.08f,.08f);

    
    // public void AddCharacter()
    
    public void MakeActive(NarrationItem narrationItem) {
        ClearCurrent();
        // speaking character has Character object
        // character positioning is based off of art1 art2 art3
        // we need to store all the art phases in the characters so we can check
        
        if (narrationItem.characterArt1.Equals(Art.NA) && 
            narrationItem.characterArt2.Equals(Art.NA) && 
            narrationItem.characterArt3.Equals(Art.NA)) return;        
       
        
        
        if (!narrationItem.characterArt1.Equals(Art.NA) &&
        !narrationItem.characterArt2.Equals(Art.NA) &&
        !narrationItem.characterArt3.Equals(Art.NA)) {
            if (!IsCurrentCharacter(narrationItem,threeLeft.transform)) {
                Darken(threeLeft.transform, shadeColor);
            }
            if (!IsCurrentCharacter(narrationItem,threeCenter.transform)) {
                Darken(threeCenter.transform, shadeColor);
            }
            if (!IsCurrentCharacter(narrationItem,threeRight.transform)) {
                Darken(threeRight.transform, shadeColor);
            }

            return;
        }
        if (!narrationItem.characterArt1.Equals(Art.NA) &&
            !narrationItem.characterArt2.Equals(Art.NA) &&
            narrationItem.characterArt3.Equals(Art.NA)) {
            if (!IsCurrentCharacter(narrationItem,twoLeft.transform)) {
                Darken(twoLeft.transform, shadeColor);
            }
            if (!IsCurrentCharacter(narrationItem,twoRight.transform)) {
                Darken(twoRight.transform, shadeColor);
            }
        }
        
        if (!narrationItem.characterArt1.Equals(Art.NA) &&
            narrationItem.characterArt2.Equals(Art.NA) &&
            !narrationItem.characterArt3.Equals(Art.NA)) {
            if (!IsCurrentCharacter(narrationItem,twoLeft.transform)) {
                Darken(twoLeft.transform, shadeColor);
            }
            if (!IsCurrentCharacter(narrationItem,twoRight.transform)) {
                Darken(twoRight.transform, shadeColor);
            }
        }
        if(narrationItem.id.Equals("[D2AK-1]")  ||
           narrationItem.id.Equals("[D2AK-2]") ||
           narrationItem.id.Equals("[D2AK-3]") ||
           narrationItem.id.Equals("[D2AK-4]")) {
            Darken(oneCenter.transform,extraDark);

        }
    }

    private bool IsCurrentCharacter(NarrationItem narrationItem, Transform parent) {
        return narrationItem.character!=null && narrationItem.character.arts.Contains((Art)Enum.Parse(typeof(Art), parent.GetChild(0).name));
    }

    private void Darken(Transform parent, Color dark) {
        if(parent.childCount == 0) return;
        if (parent.childCount == 1) {
            parent.transform.GetChild(0).GetComponent<Image>().color=dark;
        }
        else {
            parent.transform.GetChild(1).GetComponent<Image>().color=dark;
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

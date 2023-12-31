using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPositionManager : MonoBehaviour {
    public GameObject threeLeft;
    public GameObject threeCenter;
    public GameObject threeRight;
    public GameObject twoLeft;
    public GameObject twoRight;
    public GameObject oneCenter;

    public void ManagePositions(NarrationItem narrationItem, CharacterArtList characterArtList) {
        ClearCurrent();
        if (narrationItem.characterArt1.Equals(Art.NA) && 
            narrationItem.characterArt2.Equals(Art.NA) && 
            narrationItem.characterArt3.Equals(Art.NA)) return;
        if (!narrationItem.characterArt1.Equals(Art.NA) &&
            !narrationItem.characterArt2.Equals(Art.NA) &&
            !narrationItem.characterArt3.Equals(Art.NA)) {
            SetChild(characterArtList,narrationItem.characterArt1,threeLeft.transform);
            SetChild(characterArtList,narrationItem.characterArt2,threeCenter.transform);
            SetChild(characterArtList,narrationItem.characterArt3,threeRight.transform);
            return;
        }
        if (!narrationItem.characterArt1.Equals(Art.NA) &&
            !narrationItem.characterArt2.Equals(Art.NA) &&
            narrationItem.characterArt3.Equals(Art.NA)) {
            SetChild(characterArtList,narrationItem.characterArt1,twoLeft.transform);
            SetChild(characterArtList,narrationItem.characterArt2,twoRight.transform);
            return;
        }
        
        if (!narrationItem.characterArt1.Equals(Art.NA) &&
            narrationItem.characterArt2.Equals(Art.NA) &&
            !narrationItem.characterArt3.Equals(Art.NA)) {
            SetChild(characterArtList,narrationItem.characterArt1,twoLeft.transform);
            SetChild(characterArtList,narrationItem.characterArt3,twoRight.transform);
            return;
        }

        if (!narrationItem.characterArt1.Equals(Art.NA) &&
            narrationItem.characterArt2.Equals(Art.NA) &&
            narrationItem.characterArt3.Equals(Art.NA)) {
            SetChild(characterArtList,narrationItem.characterArt1,oneCenter.transform);
        
        } else if (narrationItem.characterArt1.Equals(Art.NA) &&
                   !narrationItem.characterArt2.Equals(Art.NA) &&
                   narrationItem.characterArt3.Equals(Art.NA)) {
            SetChild(characterArtList,narrationItem.characterArt2,oneCenter.transform);

        }else if (narrationItem.characterArt1.Equals(Art.NA) &&
            narrationItem.characterArt2.Equals(Art.NA) &&
            !narrationItem.characterArt3.Equals(Art.NA)) {
            SetChild(characterArtList,narrationItem.characterArt3,oneCenter.transform);

        }


    }

    public void SetChild( CharacterArtList characterArtList, Art characterArt, Transform parent) {
        GameObject o = new GameObject(characterArt.ToString());
        RectTransform rectTransform = o.AddComponent<RectTransform>();
        ArtValue artValue = characterArtList.characterArt.Find(a=>a.art.Equals(characterArt));
        float scaleFactor = 1080 / artValue.sprite.bounds.size.y;
        rectTransform.sizeDelta = new Vector2(artValue.sprite.bounds.size.x * scaleFactor, 1080);


        
        rectTransform.SetParent(parent, false);
        Image imageComponent = o.AddComponent<Image>();
        if (artValue != null) {
            imageComponent.sprite = artValue.sprite;
        }
    }

    private void ClearCurrent() {
        ClearChildren(threeLeft);
        ClearChildren(threeCenter);
        ClearChildren(threeRight);
        ClearChildren(twoLeft);
        ClearChildren(twoRight);
        ClearChildren(oneCenter);
    }

    private void ClearChildren(GameObject o) {
        foreach (Transform child in o.transform) {
            Destroy(child.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {
    public List<BackgroundArtValue> backgrounds;
    public BackgroundArtValue       current;
    [Range(0,2)]
    public float       lerpDuration;

    public  CharacterPositionManager characterPositionManager;
    public  ActiveCharacterShading   activeCharacterShading;
    private NarrationItem            _narrationItem;
    public  CharacterArtList         characterArtList;

    public void Manage(NarrationItem currentNarrative) {
        if (_narrationItem!=null && currentNarrative.id.Equals(_narrationItem.id)) return;
        _narrationItem = currentNarrative;
        FadeTo(currentNarrative.background);
    }
    private void FadeTo(Art background) {

        if (current != null && background.Equals(current.art)) {
            ManageCharacters();
            return;
        }
        var next = backgrounds.Find(b=>b.art.Equals(background));
        
        FadeOut(current);
        FadeIn(next);
        current = next;
    }

    private void FadeIn(BackgroundArtValue artValue) {
        if (artValue == null || artValue.image == null) {
            return;
        }
        StartCoroutine(Fade(artValue.image, Color.white, true));

    }
    
    private void FadeOut(BackgroundArtValue artValue) {
        if (artValue == null || artValue.image == null) {
            return;
        }

        StartCoroutine(Fade(artValue.image, Color.clear,false));
    }
    
    public IEnumerator Fade(Image image, Color targetColor,bool manage) {
        float elapsedTime = 0f;
        Color initialColor = image.color;
        bool managed = false;
        while (elapsedTime < lerpDuration) {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / lerpDuration);
            Color imageAlphaColor = Color.Lerp(initialColor, targetColor, t);
            image.color = imageAlphaColor;
            if (elapsedTime > lerpDuration / 2f && manage &&!managed) {
                ManageCharacters();
                managed = true;
            }
            yield return null;
        }

        image.color = targetColor;
    }

    public void ManageCharacters() {
        characterPositionManager.ManagePositions(_narrationItem, characterArtList);
        activeCharacterShading.MakeActive(_narrationItem);
    }
}

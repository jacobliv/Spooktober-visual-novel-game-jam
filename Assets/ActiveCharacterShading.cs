using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCharacterShading : MonoBehaviour {

    public GameObject       activeCharacter;
    public List<GameObject> backgroundCharacter;
    public Color            shadeColor;
    
    public void MakeActive(Character character) {
        if(activeCharacter.name.Equals(character.name)) return;
        if (activeCharacter!=null && !activeCharacter.name.Equals(character.name)) {
            backgroundCharacter.Add(activeCharacter);
        }

        int index = backgroundCharacter.FindIndex(0,cha=>cha.name.Equals(character.name));
        activeCharacter = backgroundCharacter[index];
        backgroundCharacter.RemoveAt(index);
        Shading();
    }

    private void Shading() {
        activeCharacter.GetComponent<Image>().color=Color.white;
        foreach (GameObject ch in backgroundCharacter) { 
            ch.GetComponent<Image>().color=shadeColor;

        }
    }
}

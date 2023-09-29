using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Character Art List", menuName = "Narrative/Character Art List")]

public class CharacterArtList : ScriptableObject {
    public List<Sprite> characterArts;

    public Sprite FindSprite(string fileName) {
        return characterArts.Find(s => s.name.Equals(fileName));
    }
}

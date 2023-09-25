using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Narrative", menuName = "Narrative/Narrative Item")]
public class NarrationItem : ScriptableObject {
    public string id;
    [Tooltip("Day the narration occurs")]
    public Day                 day;
    [Tooltip("Character who is speaking")]
    public Character character;

    public CharacterEnum characterArt;

    public bool internalThought;
    public bool physicalInteraction;

    [Tooltip("Sounds that play in order from the beginning of the narration")]
    public List<AudioClip> sounds;
    [TextArea,Tooltip("Text that is spoken by the character")]
    public string line;
    [Tooltip("Next Narrative item. 1 or more")]
    public List<NextNarrative> next;

    [Tooltip("Image to be displayed behind the characters")]
    public Sprite background;
}

public enum CharacterEnum {
    // CharacterNames
    None
}

[Serializable]
public class CurrentCharacterSprite {
    [SerializeField] public Sprite sprite;
}

[Serializable]
public class NextNarrative {
    public NextNarrative(NarrationItem narrativeItem, string shortenedLine) {
        this.narrativeItem = narrativeItem;
        this.shortenedLine = shortenedLine;
    }

    [SerializeField, Tooltip("The next narration to occur")]
    public NarrationItem narrativeItem;
    [SerializeField, Tooltip("The shortened line if needed to be displayed for a choice. Can be empty")]
    public string shortenedLine;

    public int positive;
}

public enum Day {
    Pre,
    One,
    Two,
    Three,
    Post
}

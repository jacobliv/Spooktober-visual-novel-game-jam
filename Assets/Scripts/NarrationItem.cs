using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Narrative", menuName = "Narrative/Narrative Item")]
public class NarrationItem : ScriptableObject {
    public string id;
    [TextArea,Tooltip("Text that is spoken by the character")]
    public string line;
    [Tooltip("Day the narration occurs")]
    public Day                 day;
    [Tooltip("Character who is speaking")]
    public CharacterEnum character;

    public Art characterArt;
    public DialogueType  dialogueType;
    [Tooltip("Image to be displayed behind the characters")]
    public Art background;
    [Tooltip("Next Narrative item 1")]
    public NextNarrative next1;
    
    [Tooltip("Next Narrative item 2 - for use for multiple choices")]
    public NextNarrative next2;
    [Tooltip("Sounds that play in order from the beginning of the narration")]
    public List<Sounds> sounds;
    public Sounds music;
    public Sounds ambience;


}

public enum DialogueType {
    Internal,
    Physical,
    Dialogue
}

public enum CharacterEnum {
    Omar,
    Iggy_Bumdeez,
    Spooky_Grimmother,
    Leah_Coner,
    Mason_Vorcheese,
    Ms_Gin,
    Edie_Fruguer,
    Grumpy_Old_Man,
    Akilla_Karrington,
    Unknown,
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

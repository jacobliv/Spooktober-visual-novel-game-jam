
using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class NarrativeHistory : MonoBehaviour {
    [SerializeField]
    public Dictionary<string, CharacterHistory> narrativeHistory = new();

    public Dictionary<string, int> positiveValue =new();

    public int                 choices;
    public List<NarrationItem> linearHistory   = new();
    public int                 positiveActions = 0;

    public void AddNarrativeHistory(NarrationItem currentNarrativeItem,int option) {
        if(currentNarrativeItem.next.Count<2) return;
        positiveActions+=currentNarrativeItem.next[option].positive;
        choices += 1;
        Character character = currentNarrativeItem.character;
        positiveValue[currentNarrativeItem.next[option].narrativeItem.name] = currentNarrativeItem.next[option].positive;
        narrativeHistory[character!=null ?character.name: "Narrator"]=new CharacterHistory().AddHistory(currentNarrativeItem.next[option].shortenedLine);

    }

    public void Reset() {
        narrativeHistory = new Dictionary<string, CharacterHistory>();
        positiveValue = new Dictionary<string, int>();
        choices = 0;
        linearHistory = new List<NarrationItem>();
        positiveActions = 0;
    }
}

[Serializable]
public class CharacterHistory {
    
    [SerializeField]
    public List<string> characterChoices = new();

    public CharacterHistory AddHistory(string choice) {
        characterChoices.Add(choice);
        return this;
    }
}
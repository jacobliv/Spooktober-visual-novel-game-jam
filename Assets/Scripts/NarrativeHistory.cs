
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

    public void AddNarrativeHistory(NarrationItem currentNarrativeItem,NextNarrative next) {
        linearHistory.Add(currentNarrativeItem);

        if(currentNarrativeItem.next2 == null) return;
        choices += 1;
        // TODO ADD BACK IN
        // Character character = currentNarrativeItem.character;
        positiveValue[next.narrativeItem.id] = next.value;
        // TODO ADD BACK IN
        // narrativeHistory[character!=null ?character.name: "Narrator"]=new CharacterHistory().AddHistory(next.shortenedLine);

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
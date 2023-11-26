using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData {
    public NarrationItem currentNarrative;
    public List<NarrationItem>       history;
    public int           rigorMortisValue;

    public SaveData(NarrationItem currentNarrativeItem, List<NarrationItem> narrativeHistoryLinearHistory, int value) {
        this.currentNarrative = currentNarrativeItem;
        this.history = narrativeHistoryLinearHistory;
        this.rigorMortisValue = value;
    }
}


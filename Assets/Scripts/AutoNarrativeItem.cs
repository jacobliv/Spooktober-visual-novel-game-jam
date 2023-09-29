using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static System.Globalization.CultureInfo;

public class AutoNarrativeItem : MonoBehaviour {

    public  string                            id;
    public  int                               number;
    public  Day                               day;
    public  Character                         character;
    public  bool                              phone;
    public  int                               offset;
    public  List<AudioClip>                   sounds;
    private Dictionary<string, NarrationItem> _narrationItems = new Dictionary<string, NarrationItem>();
    
    [Header("CSV File")]
    public TextAsset csvFile; // Reference to your CSV file in the Unity project.
    // private void OnValidate() {
    //     if (generate != lastGen) {
    //         lastGen = generate;
    //         Create();
    //     }
    // }

    public void Create() {
        // for (int i = 0; i < number; i++) {
        //     CreateNarrationItem(i+offset);
        // }
        Debug.Log("Loading");
        LoadDataFromCSV();
    }
    //
    private void CreateNarrationItem(int num) {
        NarrationItem newNarrationItem = ScriptableObject.CreateInstance<NarrationItem>();
        newNarrationItem.name = string.Format(id,num);
        // Set default properties here if needed

    
        AssetDatabase.CreateAsset(newNarrationItem, "Assets/Narrative/" + newNarrationItem.name + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    
    
    
    
    public void LoadDataFromCSV() {
        if (csvFile == null) {
            Debug.LogError("CSV file reference missing!");
            return;
        }
        
        string[] lines = csvFile.text.Split('\n');
        
        int startIndex = 0;
        
        
        for (int i = 1; i < lines.Length; i++) {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) {
                continue;
            }

            Debug.Log(line);
            string[] fields = line.Split("\t");
            if(fields.Length<1) continue;
            NarrationItem instance = ScriptableObject.CreateInstance<NarrationItem>();
            // Debug.Log(String.Join(",", fields.ToList()));
            instance.id = fields[0];
            List<string> list = new List<string>(fields);
            instance.line = fields[1];
            switch (fields[2]) {
                case "Day 1":
                    instance.day = Day.One;
                    break;
                case "Day 2":
                    instance.day = Day.Two;
                    break;
                case "Day 3":
                    instance.day = Day.Three;
                    break;
            }
            if (fields[3].Equals("???")) {
                instance.character = CharacterEnum.Unknown;
            }
            else {
                instance.character = (CharacterEnum)Enum.Parse(typeof(CharacterEnum), fields[3]);
            }
            if (!fields[4].Equals("N/A")) {
                instance.characterArt = (Art)Enum.Parse(typeof(Art), fields[4]);
            }

            instance.dialogueType = (DialogueType)Enum.Parse(typeof(DialogueType),fields[5]);
            
            instance.background = (Art)Enum.Parse(typeof(Art), fields[6]);
            if(!fields[11].Equals("")) {
                instance.music = (Sounds)Enum.Parse(typeof(Sounds), fields[11]);
            }

            instance.sounds = new List<Sounds>();
            if (fields[12] != "" && fields[12] != "N/A") {
                instance.sounds.Add((Sounds)Enum.Parse(typeof(Sounds), fields[12]));
            }
            if (fields[13] != "" && fields[13] != "N/A") {
                instance.sounds.Add((Sounds)Enum.Parse(typeof(Sounds), fields[13]));
            }
            if (fields[14] != "" && fields[14] != "N/A") {
                instance.sounds.Add((Sounds)Enum.Parse(typeof(Sounds), fields[14]));
            }
            if (fields[15] != "" && fields[15] != "N/A") {
                instance.sounds.Add((Sounds)Enum.Parse(typeof(Sounds), fields[15]));
            }
            instance.ambience = (Sounds)Enum.Parse(typeof(Sounds), fields[16]);

            
            _narrationItems[fields[0]] = instance;
            AssetDatabase.CreateAsset(instance, "Assets/Narrative/" + instance.id + ".asset");
        }
        //
        for (int i = 1; i < lines.Length; i++) {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) {
                continue;
            }
        
            string[] fields = line.Split('\t');
            NarrationItem narrationItem = _narrationItems[fields[0]];
            narrationItem.next1 = new NextNarrative(_narrationItems[fields[7]],fields[8]);
            if (fields[9] != "") {
                narrationItem.next2 = new NextNarrative(_narrationItems[fields[9]],fields[10]);

            }
        } 
        
    }
    // [D2D-1]	[ROD2-1]		FALSE	FALSE	TRUE				I jab my fingers against the screen of my phone the little avatar hops up and down in an effort to dodge the man-eating kale. 
}

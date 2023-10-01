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
    public CharacterList characterList;
    
    
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
            
            string[] fields = line.Split("\t");
            try {
                if(fields.Length<1) continue;
                NarrationItem instance = ScriptableObject.CreateInstance<NarrationItem>();
                // Debug.Log(String.Join(",", fields.ToList()));
                instance.id = fields[0];
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
                    instance.unknownCharacter = true ;
                }
                else if (fields[3].Equals("")){
                    // instance.character.character = CharacterEnum.None;

                }
                else {
                    Debug.Log(fields[3]);
                    instance.character = characterList.characters.Find(c=> {
                        return c.character.Equals((CharacterEnum)Enum.Parse(typeof(CharacterEnum), fields[3]));
                    });
                }

                instance.characterArt1 = Art.NA;
                instance.characterArt2 = Art.NA;
                instance.characterArt3 = Art.NA;

                if (fields.Length>4 && !fields[4].Equals("N/A") && fields[4].Trim() !="") {
                    instance.characterArt1 = (Art)Enum.Parse(typeof(Art), fields[4]);
                }
                if (fields.Length>5 && !fields[5].Equals("N/A") && fields[5].Trim() !="") {
                    instance.characterArt2 = (Art)Enum.Parse(typeof(Art), fields[5]);
                }
                if (fields.Length>6 && !fields[6].Equals("N/A") && fields[6].Trim() !="" ) {
                    Debug.Log(fields[6]);
                    instance.characterArt3 = (Art)Enum.Parse(typeof(Art), fields[6]);
                }
                
                
                if(fields.Length>7 && fields[7] != "" ) {
                    instance.dialogueType = (DialogueType)Enum.Parse(typeof(DialogueType), fields[7]);
                }            
                if(fields.Length>8 && fields[8] != "") {
                    instance.background = (Art)Enum.Parse(typeof(Art), fields[8]);
                }            
                if(fields.Length>13 && !fields[13].Equals("")) {
                    instance.music = (Sounds)Enum.Parse(typeof(Sounds), fields[13]);
                }

                instance.sounds = new List<Sounds>();
                Debug.Log(instance.id);
                if (instance.id.Equals("[D2SG-1]")) {
                    Debug.Log("HERE");
                }
                if (fields.Length>14 && fields[14] != "" && fields[14] != "N/A") {
                    instance.sounds.Add((Sounds)Enum.Parse(typeof(Sounds), fields[14]));
                }
                if (fields.Length>15 && fields[15] != "" && fields[15] != "N/A") {
                    instance.sounds.Add((Sounds)Enum.Parse(typeof(Sounds), fields[15]));
                }
                if (fields.Length>16 && fields[16] != "" && fields[16] != "N/A") {
                    instance.sounds.Add((Sounds)Enum.Parse(typeof(Sounds), fields[16]));
                }
                if (fields.Length>17 && fields[17] != "" && fields[17] != "N/A") {
                    instance.sounds.Add((Sounds)Enum.Parse(typeof(Sounds), fields[17]));
                }

                if (fields.Length > 18 && fields[18] != "") {
                    instance.ambience = (Sounds)Enum.Parse(typeof(Sounds), fields[18]);

                }

                
                _narrationItems[fields[0]] = instance;
                AssetDatabase.CreateAsset(instance, "Assets/Narrative/" + instance.id + ".asset");
            }
            catch (Exception e) {
                Debug.Log($"Failed on {line}");
            }
        }
        //
        for (int i = 1; i < lines.Length; i++) {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) {
                continue;
            }
            string[] fields = line.Split('\t');
            if (fields[0].Equals("[D2O-63]")) {
                Debug.Log("Here");
            }

            Debug.Log(fields[0]);;
            NarrationItem narrationItem = _narrationItems[fields[0]];
            string firstChoice = fields.Length > 10 ? fields[10] : "";
            if (fields.Length>9 && _narrationItems.ContainsKey(fields[9])) {
                narrationItem.next1 = new NextNarrative(_narrationItems[fields[9]],firstChoice);

            }
            if (fields.Length>11 && fields[11] != "" &&_narrationItems.ContainsKey(fields[11]) ) {
                narrationItem.next2 = new NextNarrative(_narrationItems[fields[11]],fields[12]);

            }
        } 
        
    }
    // [D2D-1]	[ROD2-1]		FALSE	FALSE	TRUE				I jab my fingers against the screen of my phone the little avatar hops up and down in an effort to dodge the man-eating kale. 
}

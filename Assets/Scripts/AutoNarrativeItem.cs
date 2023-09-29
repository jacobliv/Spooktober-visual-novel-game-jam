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
    public  List<Character>                   characters;
    public  List<AudioClip>                   sounds;
    public  CharacterArtList                  characterArt;
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
        // LoadDataFromCSV();
    }
    //
    // private void CreateNarrationItem(int num) {
    //     NarrationItem newNarrationItem = ScriptableObject.CreateInstance<NarrationItem>();
    //     newNarrationItem.name = string.Format(id,num);
    //     newNarrationItem.character = character;
    //     // Set default properties here if needed
    //     newNarrationItem.day = day;
    //     newNarrationItem.phone = phone;
    //
    //     AssetDatabase.CreateAsset(newNarrationItem, "Assets/Narrative/" + newNarrationItem.name + ".asset");
    //     AssetDatabase.SaveAssets();
    //     AssetDatabase.Refresh();
    // }
    //
    //
    //
    //
    public void LoadDataFromCSV() {
        // if (csvFile == null) {
        //     Debug.LogError("CSV file reference missing!");
        //     return;
        // }
        //
        // string[] lines = csvFile.text.Split('\n');
        //
        // int startIndex = 0;
        //
        //
        // for (int i = 0; i < lines.Length; i++) {
        //     string line = lines[i].Trim();
        //     if (string.IsNullOrEmpty(line)) {
        //         continue;
        //     }
        //
        //     string[] fields = line.Split(',');
        //     
        //     NarrationItem instance = ScriptableObject.CreateInstance<NarrationItem>();
        //     Debug.Log(String.Join(",", fields.ToList()));
        //     instance.phone = bool.Parse(fields[3]);
        //
        //     instance.shopSelection = bool.Parse(fields[4]);
        //     instance.internalThought = bool.Parse(fields[5]);
        //     instance.physicalInteraction = bool.Parse(fields[6]);
        //     var nextSounds = fields[7].Split("-");
        //     string one = nextSounds[0];
        //     if (!one.Equals("")) {
        //         instance.sounds = new List<AudioClip>() { sounds.First((a) => a.name.Equals(one)) };
        //
        //     }
        //     if (nextSounds.Length> 1) {
        //         instance.sounds.Add(sounds.First((a) => a.name.Equals(nextSounds[1])));
        //     }
        //     instance.day =Day.Two;
        //     if (fields[8] != "" && fields[8]!="None") {
        //         Character c = characters.Find((c) => c.name == fields[8]);
        //         if (c == null) {
        //             Debug.Log("Unable to find " + fields[8]);
        //         }
        //
        //         instance.character = c;
        //     }
        //
        //     CharacterEnum d = CharacterEnum.None;
        //     string fieldValue = fields[9].Trim();
        //     Debug.Log($"--{fieldValue}--");
        //
        //     if (!string.IsNullOrEmpty(fieldValue))
        //     {
        //         if (Enum.TryParse(fieldValue, true, out d))
        //         {
        //             // Parsing successful, d now contains the corresponding enum value.
        //             Debug.Log("Enum value: " + d);
        //         }
        //         else
        //         {
        //             // Parsing failed. The input string doesn't match any enum value.
        //             Debug.Log("Invalid character name: " + fieldValue);
        //         }
        //     }
        //     else
        //     {
        //         d = CharacterEnum.None;
        //     }
        //     instance.characterArt = d;
        //     List<string> lastNStrings = fields.ToList().GetRange(10,fields.Length -10);
        //
        //     // Join the last n strings using String.Joins
        //     string result = String.Join("", lastNStrings);
        //     instance.line = result.Replace("\"","");
        //     Debug.Log("Adding "+fields[0] + "---");
        //     _narrationItems[fields[0]] = instance;
        //     AssetDatabase.CreateAsset(instance, "Assets/Narrative/Generated4/" + fields[0] + ".asset");
        // }
        //
        // for (int i = 0; i < lines.Length; i++) {
        //     string line = lines[i].Trim();
        //     if (string.IsNullOrEmpty(line)) {
        //         continue;
        //     }
        //
        //     string[] fields = line.Split(',');
        //     NarrationItem narrationItem = _narrationItems[fields[0]];
        //     narrationItem.next = new List<NextNarrative>();
        //     var nexts = fields[1].Split("][");
        //     string one = nexts[0];
        //     if (!one.Equals("")) {
        //         one = one.Contains("]") ? one : one + "]";
        //         narrationItem.next.Add(new NextNarrative(false,"","",_narrationItems[one],""));
        //
        //     }
        //     if (nexts.Length> 1) {
        //         narrationItem.next.Add(new NextNarrative(false,"","",_narrationItems["["+nexts[1]],""));
        //     }
        // } 
        
    }
    // [D2D-1]	[ROD2-1]		FALSE	FALSE	TRUE				I jab my fingers against the screen of my phone the little avatar hops up and down in an effort to dodge the man-eating kale. 
}

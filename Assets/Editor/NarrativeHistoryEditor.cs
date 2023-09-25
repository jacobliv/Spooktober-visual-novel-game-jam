// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;
//
// [CustomEditor(typeof(NarrativeHistory))]
// public class NarrativeHistoryEditor : Editor
// {
//     private Dictionary<string, bool> foldouts = new Dictionary<string, bool>();
//     private GUIStyle                 characterNameStyle;
//
//     private void OnEnable()
//     {
//
//     }
//
//     public override void OnInspectorGUI()
//     {
//         characterNameStyle = new GUIStyle(EditorStyles.boldLabel) {
//
//         };
//         NarrativeHistory narrativeHistory = (NarrativeHistory)target;
//
//         // Ensure the dictionary is not null
//         if (narrativeHistory.narrativeHistory == null)
//             narrativeHistory.narrativeHistory = new Dictionary<string, CharacterHistory>();
//
//         // Set a fixed width for the character names label
//         EditorGUIUtility.labelWidth = 120;
//
//         foreach (var kvp in narrativeHistory.narrativeHistory)
//         {
//             string characterName = kvp.Key;
//             CharacterHistory characterHistory = kvp.Value;
//
//             // Check if the foldout entry exists, if not add it with default as false
//             if (!foldouts.ContainsKey(characterName))
//                 foldouts.Add(characterName, false);
//
//             // Display the foldout for the character with the custom style
//             foldouts[characterName] = EditorGUILayout.Foldout(foldouts[characterName], characterName);
//             EditorGUI.indentLevel++;
//
//             // Check if the foldout is expanded
//             if (foldouts[characterName])
//             {
//                 int count = 1;
//                 foreach (var choice in characterHistory.characterChoices)
//                 {
//                     EditorGUI.BeginDisabledGroup(true);
//                     EditorGUILayout.TextField($"{count}. {choice}");
//                     EditorGUI.EndDisabledGroup();
//                     
//                     count++;
//
//                 }
//             }
//
//             EditorGUI.indentLevel--;
//         }
//     }
// }
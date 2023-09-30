// using UnityEditor;
// using UnityEngine;
//
// // [CustomPropertyDrawer(typeof(NextNarrative))]
// public class NextNarrativeDrawer : PropertyDrawer
// {
//     private string[]      buttonNames;
//     private int           numberOfElements;
//     public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
//         return EditorGUIUtility.singleLineHeight * (numberOfElements+1) + EditorGUIUtility.standardVerticalSpacing * 4;
//     }
//
//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
//         EditorGUI.BeginProperty(position, label, property);
//
//         // Draw the label
//         position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
//         float xPos = position.x - position.width / 3;
//         float size = position.width + position.width / 3;
//         Rect triggerPosition        = new Rect(xPos,position.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 0, size, EditorGUIUtility.singleLineHeight);
//         Rect buttonPosition         = new Rect(xPos,position.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 1, size, EditorGUIUtility.singleLineHeight);
//         Rect narrativeLinePosition  = new Rect(xPos,position.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 2, size, EditorGUIUtility.singleLineHeight);
//         Rect shortenedLinePosition  = new Rect(xPos,position.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 3, size, EditorGUIUtility.singleLineHeight);
//         Rect positivePosition  = new Rect(xPos,position.y + (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * 4, size, EditorGUIUtility.singleLineHeight);
//
//         numberOfElements = 4;
//         
//
//
//         // Get SerializedProperty for each field
//         SerializedProperty choiceDependentProperty = property.FindPropertyRelative("choiceDependent");
//         SerializedProperty previousChoiceProperty = property.FindPropertyRelative("previousChoice");
//
//         SerializedProperty buttonProperty = property.FindPropertyRelative("button");
//         SerializedProperty narrativeItemProperty = property.FindPropertyRelative("narrativeItem");
//         SerializedProperty shortenedLineProperty = property.FindPropertyRelative("shortenedLine");
//         SerializedProperty positiveProperty = property.FindPropertyRelative("positive");
//
//         // Display the trigger type field
//         EditorGUI.PropertyField(triggerPosition, choiceDependentProperty);
//         if (choiceDependentProperty.boolValue) {
//             EditorGUI.PropertyField(buttonPosition, previousChoiceProperty);
//             buttonPosition.y += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);
//             narrativeLinePosition.y  += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);
//             shortenedLinePosition.y  += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing);
//             numberOfElements += 1;
//         }
//         // Display the button field
//         int selectedIndex = GetSelectedButtonIndex(buttonProperty.stringValue);
//         buttonNames = GetButtonNames();
//         string selectedButtonName = selectedIndex >= 0 && selectedIndex < buttonNames.Length ? buttonNames[selectedIndex] : "None";
//         var pos = EditorGUI.PrefixLabel(buttonPosition, GUIUtility.GetControlID(FocusType.Passive), new GUIContent("Button: "));
//         selectedIndex = EditorGUI.Popup(EditorGUI.IndentedRect(pos), selectedIndex, buttonNames);
//         if (selectedIndex >= 0 && selectedIndex < buttonNames.Length) {
//             buttonProperty.stringValue = buttonNames[selectedIndex];
//         }
//
//         // Draw the other fields
//         EditorGUI.PropertyField(narrativeLinePosition, narrativeItemProperty);
//         EditorGUI.PropertyField(shortenedLinePosition, shortenedLineProperty);
//         EditorGUI.PropertyField( positivePosition,positiveProperty);
//
//         EditorGUI.EndProperty();
//     }
//
//     private int GetSelectedButtonIndex(string buttonName)
//     {
//         for (int i = 0; i < buttonManager.buttons.Count; i++)
//         {
//             if (buttonManager.buttons[i].name == buttonName)
//             {
//                 return i;
//             }
//         }
//
//         return -1;
//     }
//
//     private string[] GetButtonNames()
//     {
//         string[] names = new string[buttonManager.buttons.Count];
//         for (int i = 0; i < buttonManager.buttons.Count; i++)
//         {
//             names[i] = buttonManager.buttons[i].name;
//         }
//
//         return names;
//     }
// }

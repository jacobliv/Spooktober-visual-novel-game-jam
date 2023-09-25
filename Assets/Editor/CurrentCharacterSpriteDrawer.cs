// using UnityEditor;
// using UnityEngine;
//
// [CustomPropertyDrawer(typeof(CurrentCharacterSprite))]
// public class CurrentCharacterSpriteDrawer : PropertyDrawer {
//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
//         EditorGUI.BeginProperty(position, label, property);
//
//         SerializedProperty spriteProperty = property.FindPropertyRelative("sprite");
//
//         // Find the parent SerializedObject to access the NarrativeItem
//         SerializedObject parentObject = property.serializedObject;
//
//         // Get the CharacterScriptableObject property from the parent object
//         SerializedProperty characterProperty = parentObject.FindProperty("character");
//
//         // Ensure the parent object and character property are valid
//         if (parentObject != null && characterProperty != null) {
//             // Get the selected character from the CharacterScriptableObject property
//             Character character = (Character)characterProperty.objectReferenceValue;
//
//             EditorGUI.BeginChangeCheck();
//
//             // If the character is valid and has sprites, show a dropdown with the available sprites
//             if (character != null && character.sprites != null && character.sprites.Count > 0) {
//                 int spriteIndex = GetSpriteIndex(character, spriteProperty);
//
//                 // Add "None" option at the beginning of the sprite names array
//                 string[] spriteNames = GetSpriteNames(character);
//                 ArrayUtility.Insert(ref spriteNames, 0, "None");
//
//                 int newSpriteIndex = EditorGUI.Popup(position, "Sprite", spriteIndex + 1, spriteNames);
//
//                 // Set the spriteProperty.objectReferenceValue to null if "None" is selected
//                 if (newSpriteIndex == 0) {
//                     spriteProperty.objectReferenceValue = null;
//                 } else {
//                     spriteProperty.objectReferenceValue = character.sprites[newSpriteIndex - 1];
//                 }
//             }
//             else {
//                 EditorGUI.LabelField(position, "No character or sprites available.");
//             }
//
//             if (EditorGUI.EndChangeCheck()) {
//                 parentObject.ApplyModifiedProperties();
//             }
//         }
//
//         EditorGUI.EndProperty();
//     }
//
//     // Get the index of the current sprite in the character's sprite list
//     private int GetSpriteIndex(Character character, SerializedProperty spriteProperty) {
//         if (character == null || character.sprites == null || character.sprites.Count == 0)
//             return -1;
//
//         Sprite sprite = (Sprite)spriteProperty.objectReferenceValue;
//         return Mathf.Max(character.sprites.IndexOf(sprite), -1);
//     }
//
//     // Get the names of the sprites in the character's sprite list
//     private string[] GetSpriteNames(Character character) {
//         if (character == null || character.sprites == null || character.sprites.Count == 0)
//             return new string[] { "No sprites available" };
//
//         string[] spriteNames = new string[character.sprites.Count];
//         for (int i = 0; i < character.sprites.Count; i++) {
//             spriteNames[i] = character.sprites[i].name;
//         }
//
//         return spriteNames;
//     }
// }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

/*if (!property.serializedObject.targetObject.name.Equals("Image")) {
            EditorGUI.PropertyField(position, property, label, true);
            return;
        }*/
[CustomPropertyDrawer(typeof(Color))]
public class ColorPaletteDrawer : PropertyDrawer {
    private       ColorPalette _palette;
    private       Color        currentValue;
    private       int          _count;
    private const float        buttonHeight = 20f; // Height of each radio button


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.PropertyField(position, property, label, true);
        if (!property.serializedObject.targetObject.name.Equals("Image") || 
            property.serializedObject.targetObject.name.Equals("ColorPalette") ) {
            return;
        }
        
        if (_palette == null) {
            _palette=  FindScriptableObject(typeof(ColorPalette)) as ColorPalette;
        }

        EditorGUI.BeginProperty(position, label, property);
        var b = position;
        
        // b.y += property.;
        property.isExpanded = EditorGUI.Foldout(b, property.isExpanded, "Color Palette", true);

        // Get the current color value
        currentValue = property.colorValue;
        if (property.isExpanded) {
            Type colorPaletteType = typeof(ColorPalette);

            FieldInfo[] fields = colorPaletteType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Rect rect = b;
            _count = 0;
            foreach (FieldInfo field in fields) {
                // Debug.Log(field.FieldType);

                if (field.FieldType == typeof(List<ColorItem>)) {
                    List<ColorItem> colorItems = field.GetValue(_palette) as List<ColorItem>;
                    if (colorItems.Count == 0) continue;
                    _count += colorItems.Count + 1;
                }
                else {
                    ColorItem colorItem = field.GetValue(_palette) as ColorItem;
                    if (colorItem.name.Equals("")) continue;
                    _count += 2;
                }
            }

            foreach (FieldInfo field in fields) {
                // Debug.Log(field.FieldType);

                if (field.FieldType == typeof(List<ColorItem>)) {
                    List<ColorItem> colorItems = field.GetValue(_palette) as List<ColorItem>;
                    if (colorItems is { Count: 0 }) continue;
                    Rect type = new Rect(rect.x, rect.y + buttonHeight, rect.width, buttonHeight);
                    EditorGUI.LabelField(type,
                                         field.Name.ToTitleCaseFromCamelCase());
                    rect = DrawColorPalettePart(rect, colorItems);
                    continue;
                }

                ColorItem colorItem = field.GetValue(_palette) as ColorItem;
                if (colorItem.name.Equals("")) continue;
                Rect a = new Rect(rect.x, rect.y + buttonHeight, rect.width, buttonHeight);
                EditorGUI.LabelField(a,
                                     field.Name.ToTitleCaseFromCamelCase());
                rect = DrawColorPaletteItem(rect, colorItem.color, colorItem.name, 0);

            }




            if (!property.colorValue.Equals(currentValue)) {
                property.colorValue = currentValue;
            }
        }

        EditorGUI.EndProperty();
    }

    private Rect DrawColorPalettePart(Rect position, List<ColorItem> list) {
        // Draw the color square
        

        Rect lastRect = position;
        // Draw radio buttons for each color
        for (int i = 0; i < list.Count; i++) {
             lastRect=DrawColorPaletteItem(position, list[i].color,list[i].name,i);
        }

        // Update the property with the selected color
        return lastRect;
    }

    private Rect DrawColorPaletteItem(Rect position, Color color, string name, int i) {
        Rect toggleRect = new Rect(position.x, position.y + buttonHeight * (i + 2), buttonHeight, buttonHeight);
        Rect colorRect = new Rect(position.x + toggleRect.x + 3, position.y + buttonHeight * (i + 2) + 3,
                                  buttonHeight - 6, buttonHeight - 6);
        Rect colorBorderRect = new Rect(position.x + toggleRect.x + 2, position.y + buttonHeight * (i + 2) + 2,
                                        buttonHeight - 4, buttonHeight - 4);
        Rect nameRect = new Rect(colorBorderRect.x + colorBorderRect.width, position.y + buttonHeight * (i + 2),
                                 position.width - toggleRect.width - colorBorderRect.width, buttonHeight);
        // Rect toggleRect = new Rect(position.x, position.y + buttonHeight * (i + 1), buttonHeight, buttonHeight);

        GUIStyle guiStyle = new GUIStyle();
        guiStyle.normal.background =
            MakeTexture(1, 1, color); // Set the background color to a light blue color
        if (GUI.Toggle(toggleRect, currentValue == color, "")) {
            currentValue = color;
        }

        GUI.DrawTexture(colorBorderRect, MakeTexture(1, 1, Color.black));
        GUI.DrawTexture(colorRect, MakeTexture(1, 1, color));
        GUI.Label(nameRect, name);
        return new Rect(position.x, position.y + buttonHeight * (i + 2), position.width, position.height);;
    }

    Texture2D MakeTexture(int width, int height, Color col) {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i) {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
    
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
        return EditorGUIUtility.singleLineHeight + buttonHeight * (property.isExpanded?_count:1);
    }
    
    
    private ScriptableObject FindScriptableObject(System.Type type) {
        string[] guids = AssetDatabase.FindAssets("t:" + type.Name);

        if (guids.Length > 0)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);
            return AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetPath);
        }

        return null;
    }
}

public static class MemberInfoGetting
{
    public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
    {
        MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
        return expressionBody.Member.Name;
    }
}

public static class StringExtensions
{
    public static string ToTitleCaseFromCamelCase(this string input)
    {
        // Use a regular expression to find all capital letters
        // followed by lowercase letters (i.e., camel case boundaries)
        string pattern = @"([a-z])([A-Z])";
        string replacement = "$1 $2";

        // Replace matches with a space and capitalize the first letter
        string result = Regex.Replace(input, pattern, replacement);

        // Capitalize the first letter of the whole string
        result = char.ToUpper(result[0]) + result.Substring(1);

        return result;
    }
}
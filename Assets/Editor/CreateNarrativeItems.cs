using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AutoNarrativeItem))] // Replace MyCustomObject with the name of your custom component class
public class CreateNarrativeItems : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        AutoNarrativeItem myCustomObject = (AutoNarrativeItem)target;

        if (GUILayout.Button("Generate")) {
            // Add your custom editor logic here
            myCustomObject.Create();
        }
    }
    
}
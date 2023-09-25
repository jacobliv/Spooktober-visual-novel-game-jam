using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "Narrative/Character")]

public class Character : ScriptableObject {
    [Tooltip("Name of character")]
    public new string      name;
    [Tooltip("Title of the character")]
    public string      title;
    [Tooltip("All the sprites associated with the character")]
    public Sprite sprite;
    

}


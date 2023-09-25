using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="ColorPalette",menuName ="Color Palette",order=0)]
public class ColorPalette : ScriptableObject {
   
    public List<ColorItem> primaryColors;
    public List<ColorItem> secondaryColors;
    public List<ColorItem> hoverColors;
    public ColorItem       lightTextColor;
    public ColorItem       darkTextColor;
    public ColorItem       backgroundColor;
    public ColorItem       accentColor;

}
[Serializable]
public class ColorItem {
    public new string name;
    public Color     color;
    
}
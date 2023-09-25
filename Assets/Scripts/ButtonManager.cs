using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {
    [SerializeField]public List<ButtonItem> buttons;
}

[Serializable]
public class ButtonItem {
    [SerializeField] public string     name;
    [SerializeField] public GameObject button;
}
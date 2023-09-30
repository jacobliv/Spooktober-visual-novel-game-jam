using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundArt : MonoBehaviour {
    public List<BackgroundArtValue> backgroundArt;
}

[Serializable]
public class BackgroundArtValue {
    [SerializeField] public Art art;
    [SerializeField] public GameObject gameObject;
}
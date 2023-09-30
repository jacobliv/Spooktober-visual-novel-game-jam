using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BackgroundArt : ScriptableObject {
    public List<BackgroundArtValue> backgroundArt;
}

[Serializable]
public class BackgroundArtValue {
    [SerializeField] public Art art;
    [SerializeField] public GameObject gameObject;
}
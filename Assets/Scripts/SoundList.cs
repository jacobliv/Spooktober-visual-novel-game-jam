using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SoundList : ScriptableObject {
    [SerializeField] public List<Sound> sounds;
    
}

[Serializable]
public class Sound {
    [SerializeField] public Sounds    sound;
    [SerializeField] public AudioClip audioClip;
    [SerializeField] public string    eventValue;
}
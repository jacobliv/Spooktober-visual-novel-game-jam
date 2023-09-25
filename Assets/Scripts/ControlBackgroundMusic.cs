using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBackgroundMusic : MonoBehaviour {
    public AudioSource source;
    public AudioClip   supernova;
    public AudioClip   supernovaAlt;
    public AudioClip   bracingForImpact;

    public void ChangeSong(string song) {
        switch (song) {
            case "SupernovaAlt":
                ChangeSong(Songs.SupernovaAlt);
                break;
            case "Supernova":
                ChangeSong(Songs.Supernova);

                break;
            case "BracingForImpact":
                ChangeSong(Songs.BracingForImpact);

                break;
        }
    }
    
    public void ChangeSong(Songs song) {
        AudioClip currentClip;
        switch (song) {
            case Songs.SupernovaAlt:
                currentClip = supernovaAlt;

                break;
            case Songs.Supernova:
                currentClip = supernova;

                break;
            case Songs.BracingForImpact:
                currentClip = bracingForImpact;

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(song), song, null);
        }
        if(source.clip.name.Equals(currentClip.name)) return;

        source.Stop();
        source.clip = currentClip;
        source.Play();
    }
    
    
}


public enum Songs{
    SupernovaAlt,
    Supernova,
    BracingForImpact

}
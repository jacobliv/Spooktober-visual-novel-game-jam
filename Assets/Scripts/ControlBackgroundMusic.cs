using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBackgroundMusic : MonoBehaviour {
    public AudioSource musicSource;
    public AudioSource ambientSource;

    public List<AudioClip> ambientSounds;
    public List<AudioClip> music;

    public void ChangeSong(Sounds song) {
        
    }
    
    // public void ChangeAmbient(Sounds ambience) {
    //     ambientSounds.Find(amb=>amb)
    // }
    
    public void ChangeSong(Songs song) {
        // AudioClip currentClip;
        // switch (song) {
        //     case Songs.SupernovaAlt:
        //         currentClip = supernovaAlt;
        //
        //         break;
        //     case Songs.Supernova:
        //         currentClip = supernova;
        //
        //         break;
        //     case Songs.BracingForImpact:
        //         currentClip = bracingForImpact;
        //
        //         break;
        //     default:
        //         throw new ArgumentOutOfRangeException(nameof(song), song, null);
        // }
        // if(source.clip.name.Equals(currentClip.name)) return;
        //
        // source.Stop();
        // source.clip = currentClip;
        // source.Play();
    }
    
    
}


public enum Songs{
    SupernovaAlt,
    Supernova,
    BracingForImpact

}
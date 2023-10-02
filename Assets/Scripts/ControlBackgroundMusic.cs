using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBackgroundMusic : MonoBehaviour {
    public static ControlBackgroundMusic instance;
    public        AudioSource            musicSource;
    public        AudioSource            ambientSource;

    public List<Sound> ambientSounds;
    public List<Sound> music;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void ChangeSong(Sounds song) {
        if(song.Equals(Sounds.None)) {
            musicSource.Stop();
            musicSource.clip = null;
            return;
        }
        Sound sound = music.Find(m=>m.sound.Equals(song));
        if( sound == null) return;
        if (musicSource.clip == null || (musicSource.clip != null && !musicSource.clip.name.Equals(sound.audioClip.name))) {
            ChangeSound(sound.audioClip,musicSource);

        }

        
    }
    
    public void ChangeAmbient(Sounds ambience) {
        if(ambience.Equals(Sounds.None)) {
            ambientSource.Stop();
            return;
        }
        Sound ambienceSound = ambientSounds.Find(m=>m.sound.Equals(ambience));
        if(ambienceSound == null ||(ambientSource.clip!=null && ambientSource.clip.name.Equals(ambienceSound.audioClip.name))) return;
        ChangeSound(ambienceSound.audioClip,ambientSource);
    }
    
    public void ChangeSound(AudioClip song,AudioSource source) {
        source.Stop();
        source.clip = song;
        source.Play();
    }
    
    
}


public enum Songs{
    SupernovaAlt,
    Supernova,
    BracingForImpact

}
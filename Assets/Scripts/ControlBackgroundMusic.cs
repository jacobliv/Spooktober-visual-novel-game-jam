using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class ControlBackgroundMusic : MonoBehaviour {
    public static  ControlBackgroundMusic instance;
    public         List<Sound>            music;
    public         List<Sound>            ambienceSounds;
    private        float                  currentVolume;
    private        float                  targetVolume;
    private static EventInstance          music_control;
    private static EventInstance          ambience_control;
    private        string                 musicEvent;
    private        string                 ambienceEvent;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }

        // currentVolume = musicSource.volume;
    }

    public void ChangeSong(Sounds song) {
        if(song.Equals(Sounds.None)) {
            StopSound(ref music_control,ref musicEvent);
            return;
        }
        Sound sound = music.Find(m=>m.sound.Equals(song));
        if (sound == null) {
            StopSound(ref music_control,ref musicEvent);
            return;
        }
        PlaySound(sound,ref music_control, ref musicEvent);
    }
    
    public void ChangeAmbient(Sounds ambience) {
        if(ambience.Equals(Sounds.None)) {
            StopSound(ref ambience_control, ref ambienceEvent);
            return;
        }
        Sound sound = ambienceSounds.Find(m=>m.sound.Equals(ambience));
        if (sound == null) {
            StopSound(ref ambience_control, ref ambienceEvent);
            return;
        }
        PlaySound(sound,ref ambience_control,ref ambienceEvent);
    }

    public void StopSound(ref EventInstance inst, ref string soundEvent) {
        Debug.Log($"Stopping {soundEvent}");
        inst.stop(STOP_MODE.ALLOWFADEOUT);
        soundEvent = "";

    }
    // TODO Going back doesnt re
    public void PlaySound(Sound sound, ref EventInstance inst, ref string soundEvent) {
        if (soundEvent!=null && soundEvent.Equals(sound.eventValue)) {
            return;
        }
        
        EventReference eventReference = EventReference.Find(sound.eventValue);
        if (!eventReference.Equals(null)) {
            Debug.Log("About to play: " + eventReference.Path);
            inst.stop(STOP_MODE.ALLOWFADEOUT);
            inst = RuntimeManager.CreateInstance(eventReference.Path);
            inst.start();
            inst.release();
            soundEvent = eventReference.Path;

        } else {
            Debug.LogError("Event reference not found for path: " + sound.eventValue);
        }
    }
    
    
}

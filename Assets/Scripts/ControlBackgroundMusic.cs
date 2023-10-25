using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBackgroundMusic : MonoBehaviour {
    public static ControlBackgroundMusic instance;
    public        AudioSource            musicSource;
    public        AudioSource            ambientSource;

    public  List<Sound> ambientSounds;
    public  List<Sound> music;
    private float       currentVolume;
    private float       targetVolume;
    public  float       transitionDuration = 2.0f; // Editable transition duration in seconds

    private void Awake() {
        if (instance == null) {
            instance = this;
        }

        currentVolume = musicSource.volume;
    }

    public void ChangeSong(Sounds song) {
        if(song.Equals(Sounds.None)) {
            StartCoroutine(FadeOutMusic());
            musicSource.clip = null;
            return;
        }
        Sound sound = music.Find(m=>m.sound.Equals(song));
        if( sound == null) return;
        if (musicSource.clip == null || (musicSource.clip != null && !musicSource.clip.name.Equals(sound.audioClip.name))) {
            StartCoroutine(CrossfadeMusic(sound.audioClip));
            // ChangeSound(sound.audioClip,musicSource);

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
    
    private IEnumerator CrossfadeMusic(AudioClip newTrack) {
        targetVolume = 0.0f;

        // Fade out the current music
        float startVolume = musicSource.volume;
        float startTime = Time.time;
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration) {
            elapsedTime = Time.time - startTime;
            musicSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / transitionDuration);
            yield return null;
        }

        musicSource.volume = targetVolume;
        musicSource.Stop();

        // Change to the new music track
        musicSource.clip = newTrack;
        musicSource.Play();

        // Fade in the new music
        targetVolume = currentVolume;
        startTime = Time.time;
        elapsedTime = 0;

        while (elapsedTime < transitionDuration) {
            elapsedTime = Time.time - startTime;
            // Debug.Log(musicSource.volume);

            musicSource.volume = Mathf.Lerp(targetVolume, musicSource.volume, elapsedTime / transitionDuration);
            yield return null;
        }

        musicSource.volume = currentVolume;
    }
    
    private IEnumerator FadeOutMusic()
    {
        targetVolume = 0.0f;
    
        float startVolume = musicSource.volume;
        float startTime = Time.time;
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration) {
            elapsedTime = Time.time - startTime;
            musicSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / transitionDuration);
            yield return null;
        }

        musicSource.volume = targetVolume;
        musicSource.Stop();
    }
    
}


public enum Songs{
    SupernovaAlt,
    Supernova,
    BracingForImpact

}
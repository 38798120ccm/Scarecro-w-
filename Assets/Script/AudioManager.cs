using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class AudioManager : MonoBehaviour
{

    public static AudioManager plugin;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake() {
        if (plugin == null) {
            plugin = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    // If you need background music
    private void Start() {
        // play BGM on start
        playMusic("wtf");

    }
    

    public void playMusic(string name) {

        // Find "name" in Music sound[] array
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null) {
            Debug.Log("Sound is not found!");
            return;
        }

        // If sound is found
        musicSource.clip = s.clip;
        musicSource.Play();

    }

    public void playSFX(string name) {

        // Find "name" in Sfx sound[] array
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null) {
            Debug.Log("Sound is not found!");
            return;
        }

        // Play if found
        sfxSource.PlayOneShot(s.clip);

    }

    public void toggleMusic() {
        musicSource.mute = !musicSource.mute;
    }

    public void toggleSFX() {
        sfxSource.mute = !sfxSource.mute;
    }

    public void setMusicVolume(float volume) {
        musicSource.volume = volume;
    }

    public void setSFXVolume(float volume) {
        sfxSource.volume = volume;
    }
}

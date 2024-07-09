using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    // Setting Panel's GameObject
    public GameObject panel;
    // Music/SFX volume settings
    public Slider musicSlider, sfxSlider;

    public void previous() {
        if (panel.activeSelf) {
            panel.SetActive(false);
        }
    }

    public void toggleMusic() {
        AudioManager.plugin.toggleMusic();
    }

    public void toggleSFX() {
        AudioManager.plugin.toggleSFX();
    }

    public void setMusicVolume() {
        float value = musicSlider.value;
        AudioManager.plugin.setMusicVolume(value);
        PlayerPrefs.SetFloat("settings.musicvolume", value);
    }

    public void setSFXVolume() {
        float value = sfxSlider.value;
        AudioManager.plugin.setSFXVolume(value);
        PlayerPrefs.SetFloat("settings.sfxvolume", value);
    }

    public void toggleFullScreen() {
        Screen.fullScreen = !Screen.fullScreen;
    }

    void initalizeVolume() {
        if (PlayerPrefs.HasKey("settings.musicvolume")) {
            float value = PlayerPrefs.GetFloat("settings.musicvolume");
            musicSlider.SetValueWithoutNotify(value);
        }

        if (PlayerPrefs.HasKey("settings.sfxvolume")) {
            float value = PlayerPrefs.GetFloat("settings.sfxvolume");
            sfxSlider.SetValueWithoutNotify(value);
        }
    }

    void Start() {
        initalizeVolume();
    }
}

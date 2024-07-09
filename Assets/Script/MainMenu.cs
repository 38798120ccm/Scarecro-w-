using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Reflection;

public class MainMenu : MonoBehaviour
{

    // Quit Confirmation Panel
    public GameObject quitPanel;
    // Music/SFX volume settings
    public Slider musicSlider, sfxSlider;

    // Load the game from the main menu
    // [Obsolete("Optional")]
    public void startGame() {
        // default value 1 can be a string.
        SceneManager.LoadScene(1);
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

    // Not really quit the game.
    // this will call the confirmation of quitting game.
    public void quitGame() {

        // 

        // Check if the menu is being opened already.
        if (quitPanel.activeSelf) {
            return;
        }

        quitPanel.SetActive(true);
    }


    // Quit Confirmation Menu

    public void cancelQuit() {
        if (quitPanel.activeSelf) {
            quitPanel.SetActive(false);
        }
    }

    public void realQuit() {
        Application.Quit();
    }

    // End of Quit Confirmation Menu

    public void Start() {
        quitPanel.SetActive(false);
        initalizeVolume();
    }

    void initalizeVolume() {
        if (PlayerPrefs.HasKey("settings.musicvolume")) {
            float value = PlayerPrefs.GetFloat("settings.musicvolume");
            AudioManager.plugin.setMusicVolume(value);
            musicSlider.SetValueWithoutNotify(value);
        }

        if (PlayerPrefs.HasKey("settings.sfxvolume")) {
            float value = PlayerPrefs.GetFloat("settings.sfxvolume");
            AudioManager.plugin.setSFXVolume(value);
            sfxSlider.SetValueWithoutNotify(value);
        }
    }

    
}

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
        AudioManager.plugin.setMusicVolume(musicSlider.value);
    }

    public void setSFXVolume() {
        AudioManager.plugin.setSFXVolume(sfxSlider.value);
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
    }

    
}

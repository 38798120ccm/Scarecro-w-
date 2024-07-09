using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    // Setting Panel
    public GameObject settingPanel;
    
    // Pause Panel
    public GameObject panel;

    // Quitting Panel
    public GameObject quittingPanel;

    public static bool onPause = false;

    // Back to game
    public void resume() {
        panel.SetActive(false);
        onPause = false;
        Time.timeScale = 1;
    }

    void pause() {
        panel.SetActive(true);
        onPause = true;
        Time.timeScale = 0;
    }

    // Open Setting Menu
    public void openSettingMenu() {
        if (!settingPanel.activeSelf) {
            settingPanel.SetActive(true);
        }
    }

    // Back To Main Menu
    public void backToMain() {
        SceneManager.LoadScene(1);
    }

    // Open Confirmation of Quitting Game
    public void quitGame() {
        if (!quittingPanel.activeSelf) {
            quittingPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() {
        togglePause();
    }

    void FixedUpdate()
    {
    }

    void Start() {
    }

    void togglePause() {
        if (Input.GetButtonDown("Cancel")) {
            if (!onPause) {
                pause();
                return;
            }

            if (quittingPanel.activeSelf) {
                cancelQuit();
                return;
            }

            if (settingPanel.activeSelf) {
                settingPanel.SetActive(false);
                return;
            }
            resume();
        }
    }


    // Methods for Quitting Confirmation Menu
    public void cancelQuit() {
        if (quittingPanel.activeSelf) {
            quittingPanel.SetActive(false);
        }
    }

    public void realQuit() {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsScriptMain : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;

    // Screens:
    public GameObject mainScreen;
    public GameObject settingsScreen;

    void Start()
    {
        playButton.onClick.AddListener(openLevelScene);
        settingsButton.onClick.AddListener(openSettingsScreen);
    }

    private void openSettingsScreen()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    private void openLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }
}

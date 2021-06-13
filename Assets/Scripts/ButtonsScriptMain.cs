using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsScriptMain : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;

    public Sprite playButtonPressedSprite, playButtonUnpressedSprite, settingsButtonPressedSprite, settingsButtonUnpressedSprite;

    // Screens:
    public GameObject mainScreen;
    public GameObject settingsScreen;

    public Text playText;
    public Text settingsText;

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

    public void onPlayButtonDown()
    {
        playButton.GetComponent<Image>().sprite = playButtonPressedSprite;
        playText.color = Color.white;
    }

    public void onPlayButtonUp()
    {
        playButton.GetComponent<Image>().sprite = playButtonUnpressedSprite;
        playText.color = Color.black;
    }

    public void onSettingsButtonDown()
    {
        settingsButton.GetComponent<Image>().sprite = settingsButtonPressedSprite;
        settingsText.color = Color.white;
    }

    public void onSettingsButtonUp()
    {
        settingsButton.GetComponent<Image>().sprite = settingsButtonUnpressedSprite;
        settingsText.color = Color.black;
    }
}

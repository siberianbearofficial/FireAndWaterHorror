using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    public Button backButton;
    public GameObject mainScreen;
    public GameObject settingsScreen;
    public Sprite pressedButtonSprite, unpressedButtonSprite;
    
    void Start()
    {
        backButton.onClick.AddListener(openMainScreen);
    }

    private void openMainScreen()
    {
        settingsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void onDown()
    {
        backButton.GetComponent<Image>().sprite = pressedButtonSprite;
    }

    public void onUp()
    {
        backButton.GetComponent<Image>().sprite = unpressedButtonSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    public Button backButton;
    public GameObject mainScreen;
    public GameObject settingsScreen;
    
    void Start()
    {
        backButton.onClick.AddListener(openMainScreen);
    }

    private void openMainScreen()
    {
        settingsScreen.SetActive(false);
        mainScreen.SetActive(true);
    }
}

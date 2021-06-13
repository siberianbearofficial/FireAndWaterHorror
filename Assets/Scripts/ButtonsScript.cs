using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    public Button backButton;
    
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(openMainScene);
    }

    private void openMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

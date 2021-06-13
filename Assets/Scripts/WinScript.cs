using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            winScreen.SetActive(true);
            StartCoroutine(youWin());
        }
    }

    IEnumerator youWin()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }
}

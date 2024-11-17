using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public void PlayBtn() {
        Debug.Log("PlayBtn clicked");
        SceneManager.LoadScene("VRScene");
    }
    public void AboutBtn() {
        Debug.Log("AboutBtn clicked");

    }
    public void OptionsBtn() {
        Debug.Log("OptionsBtn clicked");
    }
    public void QuitBtn() {
        Debug.Log("QuitBtn clicked");
        Application.Quit();
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    public void PlayBtn()
    {
        Debug.Log("PlayBtn clicked");
        SceneManager.LoadScene("VRScene");
    }
    public void AgainBtn()
    {
        Debug.Log("AgainBtn clicked");
        SceneManager.LoadScene("VRScene");
    }
    public void MainMenuBtn()
    {
        Debug.Log("MainMenuBtn clicked");
        SceneManager.LoadScene("Start Scene");
    }
    public void AboutBtn()
    {
        Debug.Log("AboutBtn clicked");

    }
    public void OptionsBtn()
    {
        Debug.Log("OptionsBtn clicked");
    }
    public void QuitBtn()
    {
        Debug.Log("QuitBtn clicked");
        Application.Quit();
    }


}
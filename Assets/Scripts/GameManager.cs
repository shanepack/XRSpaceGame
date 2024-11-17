using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    void Awake()
    {
        // Implement singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Public method to start the coroutine
    public void LoadGameOverSceneWithDelay(float delay)
    {
        StartCoroutine(LoadGameOverSceneCoroutine(delay));
    }

    // The coroutine that loads the GameOver scene after a delay
    private IEnumerator LoadGameOverSceneCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }
}

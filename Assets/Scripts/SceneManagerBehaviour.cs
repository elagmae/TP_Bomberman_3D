using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void Reload()
    {
        Time.timeScale = 1f;

        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(currentScene);
    }

    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        
    }
}

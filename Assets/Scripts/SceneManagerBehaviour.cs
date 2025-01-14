using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator _transition;
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        _transition.SetTrigger("Start");

        StartCoroutine(WaitAndLoad(sceneName));
    }

    public IEnumerator WaitAndLoad(string sceneName)
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void Reload()
    {
        Time.timeScale = 1f;
        _transition.SetTrigger("Start");
        var currentScene = SceneManager.GetActiveScene().name;
        StartCoroutine(WaitAndLoad(currentScene));
    }

    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        
    }
}

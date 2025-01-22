using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

public class SceneManagerTests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Menu");

    }

    [UnityTest]
    public IEnumerator SceneManagerBehaviourChangeToExistingSceneTest()
    {
        var smb = Object.FindObjectOfType<SceneManagerBehaviour>();
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        
        bool error = false;
        
        try
        {
            smb.LoadScene("PvE");
        }
        catch(Exception e)
        {
            Debug.LogError($"Failed to load scene 'PvE'. Error {e.GetType().Name}: {e.Message}");
            error = true;
        }
        
        yield return new WaitForSeconds(4f);

        Assert.That(error, Is.False);
        Assert.That(currentSceneName, !(Is.EqualTo("PvE")));
        Assert.That(SceneManager.GetActiveScene().name, Is.EqualTo("PvE"));
    }

    [UnityTest]
    public IEnumerator SceneManagerBehaviourReloadSceneTest()
    {
        var smb = Object.FindObjectOfType<SceneManagerBehaviour>();
        string currentSceneName = SceneManager.GetActiveScene().name;

        bool error = false;
        
        try
        {
            smb.Reload();
        }
        catch(Exception e)
        {
            Debug.LogError($"Failed to load scene '{currentSceneName}'. Error {e.GetType().Name}: {e.Message}");
            error = true;
        }
        
        yield return new WaitForSeconds(4f);
        
        Assert.That(error, Is.False);
        Assert.That(currentSceneName, (Is.EqualTo(SceneManager.GetActiveScene().name)));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 3f;

    [SerializeField] int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
        Debug.Log("This Scene " + currentSceneIndex);
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Loading Scene from " + currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

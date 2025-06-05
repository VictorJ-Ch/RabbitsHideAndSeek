using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public bool isLoadingScene;
    public bool isDeadScene;
    public bool isCreditsScene;

    void Update()
    {
        if (isLoadingScene)
        {
            StartCoroutine(DelayedSceneChange());
            isLoadingScene = false;
        }
        if (isDeadScene)
        {
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(ReadingDeadPanel());
            isDeadScene = false;
        }
        if (isCreditsScene)
        {
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(ReadingCredits());
            isCreditsScene = false;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Cambiando a: " + sceneName);
    }

    public void QuitApp()
    {
        Debug.Log("Game's closing");
        Application.Quit();
    }

    IEnumerator DelayedSceneChange()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(sceneName);
    }


    IEnumerator ReadingDeadPanel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator ReadingCredits()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(sceneName);
    }
}

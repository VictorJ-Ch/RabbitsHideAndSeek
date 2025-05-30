using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; 
    public bool isLoadingScene;
    public bool isDeadScene;

    void Update()
    {
        if(isLoadingScene)
        {
            StartCoroutine(DelayedSceneChange());
            isLoadingScene = false;
        }
        if(isDeadScene)
        {
            Cursor.lockState = CursorLockMode.None;
            StartCoroutine(ReadingDeadPanel());
            isDeadScene = false;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Cambiando a: " + sceneName);
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
}

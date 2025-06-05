using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        ActorType actor = other.GetComponent<ActorType>();

        if (actor != null && actor.isPlayer)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

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
            Debug.Log($"Trigger activado por {other.gameObject.name}, cambiando a escena: {sceneName}");
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log($"Trigger con {other.gameObject.name}, pero no es un jugador.");
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    void OnCollisionEnter(Collision collision)
    {
        ActorType actor = collision.gameObject.GetComponent<ActorType>();

        if (actor != null)
        {
            TomarDaño(34, actor);
        }
    }

    public void TomarDaño(int daño, ActorType actor)
    {
        vidaActual -= daño;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        if (vidaActual <= 0)
        {
            Morir(actor);
        }
    }

    void Morir(ActorType actor)
    {
        Debug.Log("El jugador ha muerto.");

        if (actor.isBear)
        {
            SceneManager.LoadScene("BearDeadScene");
        }
        else if (actor.isRat)
        {
            SceneManager.LoadScene("RataDeadScene");
        }
        else if (actor.isHumanoide)
        {
            SceneManager.LoadScene("HumanoidDeadScene");
        }
    }
}

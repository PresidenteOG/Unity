using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public GameObject Win; // Objeto o mensaje de victoria (opcional)

    // Se ejecuta al detectar una colisión
    private void OnCollisionEnter(Collision collision)
    {
        // Si el jugador toca este objeto
        if (collision.transform.CompareTag("Player"))
        {
            // Carga la siguiente escena (siguiente nivel)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

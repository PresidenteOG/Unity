using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    // Se ejecuta cuando algo colisiona con este objeto
    private void OnCollisionEnter(Collision collision)
    {
        // Si el objeto que toca tiene la etiqueta "Player"
        if (collision.transform.CompareTag("Player"))
        {
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

using UnityEngine;

public class PurpleCollectible : MonoBehaviour
{
    public AudioClip collectSound; // Sonido al recoger el objeto
    public float volume = 1f;      // Volumen del sonido

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER"); // Mensaje de prueba en consola

        // Si el jugador entra en el trigger
        if (other.CompareTag("Player")) // Asegúrate de que el tag sea "Player"
        {
            // Reproduce el sonido
            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);

            // Avisa al script Mysterys que se recogió un coleccionable
            FindAnyObjectByType<Mysterys>()?.AddPurpleCollectible();

            // Desactiva el objeto (ya fue recogido)
            gameObject.SetActive(false);
        }
    }
}

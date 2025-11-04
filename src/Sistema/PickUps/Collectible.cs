using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip collectSound; // Sonido al recoger
    public float volume = 1f;      // Volumen del sonido

    private void OnCollisionEnter(Collision collision)
    {
        // Si colisiona con el jugador
        if (collision.transform.CompareTag("Player"))
        {
            // Reproduce el sonido en la posición del objeto
            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position, volume);

            // Avisa al GameManager que se recogió un objeto
            FindAnyObjectByType<GameManager>()?.AddCollectible();

            // Desactiva el objeto (simula que fue recogido)
            gameObject.SetActive(false);
        }
    }
}

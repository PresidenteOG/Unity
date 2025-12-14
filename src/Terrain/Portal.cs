using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    [Header("Cámaras")]
    public GameObject startCamera;     // Cámara inicial
    public GameObject Personaje;   // Cámara o jugador principal

    [Header("Configuración")]
    public Transform effect;       // Objeto visual del portal
    public float shrinkSpeed = 3f; // Velocidad de reducción del efecto

    public AudioClip collectSound; // Sonido al activarse
    private bool shrinking = true; // Control del efecto

    void Start()
    {
        // Activa la cámara inicial y desactiva al personaje
        if (startCamera != null) startCamera.SetActive(true);
        if (Personaje != null) Personaje.SetActive(false);

        // Reproduce el sonido del portal
        if (collectSound != null)
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 1f);
    }

    void Update()
    {
        // Reduce el tamaño del efecto del portal
        if (shrinking && effect != null)
        {
            Vector3 scale = effect.localScale;
            scale.y = Mathf.MoveTowards(scale.y, 0f, shrinkSpeed * Time.deltaTime);
            effect.localScale = scale;

            // Cuando el efecto termina, cambia de cámara al jugador
            if (scale.y <= 0f)
            {
                shrinking = false;
                if (startCamera != null) startCamera.SetActive(false);
                if (Personaje != null) Personaje.SetActive(true);
            }
        }
    }
}

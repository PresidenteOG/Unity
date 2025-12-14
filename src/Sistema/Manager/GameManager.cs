using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public CompleteNote completeNote;     // Referencia a la nota o mensaje al completar
    public string doorDisplayName = "la Puerta Amarillo"; // Nombre que se muestra al abrir la puerta
    public TMP_Text collectiblesText;     // Texto en pantalla con la cantidad de monedas
    public GameObject gate;               // Puerta o barrera que se abre al completar
    public GameObject monedas;            // Contenedor de todas las monedas
    public AudioClip Gate;                // Sonido al abrir la puerta
    public float volume = 1f;             // Volumen del sonido

    int current = 0;  // Monedas recogidas
    int total = 0;    // Total de monedas

    void Start()
    {
        // Calcula cuántas monedas hay en total (resta 1 por el objeto padre)
        if (monedas != null)
            total = monedas.GetComponentsInChildren<Transform>(true).Length - 1;

        ActualizarTexto(); // Muestra el texto inicial
    }

    public void AddCollectible()
    {
        current++;          // Suma una moneda
        ActualizarTexto();  // Actualiza el texto

        // Si se recogieron todas las monedas
        if (current >= total && gate != null)
        {
            if (Gate != null)
                AudioSource.PlayClipAtPoint(Gate, transform.position, volume); // Reproduce el sonido
            gate.SetActive(false); // Abre la puerta

            if (completeNote != null)
                completeNote.ShowDoorOpened(doorDisplayName); // Muestra mensaje de puerta abierta
        }
    }

    void ActualizarTexto()
    {
        // Actualiza el texto de monedas en pantalla
        collectiblesText.text = $"[{current}/{total}]";
    }
}

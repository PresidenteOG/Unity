using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Mysterys : MonoBehaviour
{
    public CompleteNote completeNote;        // Referencia al mensaje de logro
    public string doorDisplayName = "Encontraste todos los easter eggs!"; // Texto mostrado al completar
    public TMP_Text collectiblesText;        // Texto que muestra el progreso
    public GameObject monedas;               // Contenedor de los objetos coleccionables
    public AudioClip Music;                  // Música o sonido especial
    public float volume = 1f;                // Volumen del sonido

    int current = 0; // Cantidad recogida
    int total = 0;   // Total de coleccionables

    void Start()
    {
        // Calcula cuántos coleccionables hay (restando el objeto padre)
        if (monedas != null)
            total = monedas.GetComponentsInChildren<Transform>(true).Length - 1;

        ActualizarTexto(); // Muestra el progreso inicial
    }

    // Suma un coleccionable púrpura
    public void AddPurpleCollectible()
    {
        current++;
        ActualizarTexto();

        // Si se recolectaron todos
        if (current >= total)
        {
            // Reproduce la música o sonido especial
            if (Music != null)
                AudioSource.PlayClipAtPoint(Music, transform.position, volume);

            // Muestra el mensaje de logro
            if (completeNote != null)
                completeNote.ShowDoorOpened(doorDisplayName);
        }
    }

    // Actualiza el texto de progreso
    void ActualizarTexto()
    {
        collectiblesText.text = $"[{current}/{total}]";
    }
}

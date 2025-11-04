using UnityEngine;
using TMPro;

public class CompleteNote : MonoBehaviour
{
    public TMP_Text textLabel;          // Texto que muestra el mensaje
    RectTransform rect;                 // Referencia al rect transform del UI

    public float duration = 3f;         // Duración del mensaje
    public float magnitude = 12f;       // Intensidad del movimiento
    public float frequency = 40f;       // Frecuencia del movimiento

    public Color messageColor = new Color(1f, 1f, 0f); // Color del mensaje (amarillo)

    [Header("Audio")]
    public AudioClip notificationSFX;   // Sonido al mostrar el mensaje
    private AudioSource audioSrc;       // Fuente de audio

    Coroutine routine;                  // Guarda la rutina activa

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        if (textLabel == null) textLabel = GetComponent<TMP_Text>();

        // Crea un AudioSource si no existe
        audioSrc = GetComponent<AudioSource>();
        if (audioSrc == null)
            audioSrc = gameObject.AddComponent<AudioSource>();

        audioSrc.playOnAwake = false;
        audioSrc.spatialBlend = 0f; // Sonido 2D

        gameObject.SetActive(false); // Oculta el mensaje al iniciar
    }

    // Muestra un mensaje personalizado
    public void ShowMessage(string message)
    {
        if (textLabel)
        {
            textLabel.text = message;
            textLabel.color = messageColor;
        }

        gameObject.SetActive(true);

        // Reproduce el sonido
        if (notificationSFX != null)
            audioSrc.PlayOneShot(notificationSFX);

        // Inicia el efecto de movimiento
        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(ShakeThenHide());
    }

    // Efecto de vibración y ocultar después del tiempo
    System.Collections.IEnumerator ShakeThenHide()
    {
        Vector2 basePos = rect.anchoredPosition;
        float t = 0f;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            float x = Mathf.Sin(t * frequency) * magnitude;
            float y = Mathf.Cos(t * frequency * 0.9f) * (magnitude * 0.6f);
            rect.anchoredPosition = basePos + new Vector2(x, y);
            yield return null;
        }

        rect.anchoredPosition = basePos;
        gameObject.SetActive(false);
        routine = null;
    }

    // Muestra un mensaje específico de puerta abierta
    public void ShowDoorOpened(string doorName)
    {
        ShowMessage($"¡Se abrió {doorName}!");
    }
}

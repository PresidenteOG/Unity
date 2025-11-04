using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public Toggle toggle;               // Toggle del Canvas
    public AudioSource musicSource;     // Fuente de audio de la música
    const string MUSIC_MUTE_KEY = "MusicMuted"; // Clave para guardar el estado

    void Start()
    {
        if (toggle == null) toggle = GetComponent<Toggle>(); // Obtiene el toggle si no está asignado
        if (musicSource == null) Debug.LogWarning("🎧 Falta asignar el AudioSource de la música.");

        // Carga el estado guardado (1 = silenciado)
        bool muted = PlayerPrefs.GetInt(MUSIC_MUTE_KEY, 0) == 1;

        // Actualiza el toggle y el audio
        toggle.isOn = !muted;
        if (musicSource != null) musicSource.mute = muted;

        // Agrega el listener al toggle
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    // Se ejecuta cuando el toggle cambia
    void OnToggleChanged(bool isOn)
    {
        bool muted = !isOn;

        if (musicSource != null)
            musicSource.mute = muted;

        // Guarda el estado
        PlayerPrefs.SetInt(MUSIC_MUTE_KEY, muted ? 1 : 0);
        PlayerPrefs.Save();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject pausePanel;     // Panel con botones: Continuar, Configuraciones, Exit
    public GameObject settingsPanel;  // Panel de configuraciones (opcional)
    public GameObject firstPauseButton;    // Botón seleccionado al abrir pausa
    public GameObject firstSettingsButton; // Botón seleccionado al abrir settings

    [Header("Input")]
    public KeyCode toggleKey = KeyCode.Escape;

    [Header("Exit")]
    public bool exitToMenu = true;
    //public string menuSceneName = "MainMenu";

    bool isPaused;

    void Start()
    {
        // Asegura que empieza sin pausa
        SetPaused(false);
        if (pausePanel) pausePanel.SetActive(false);
        if (settingsPanel) settingsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        SetPaused(!isPaused);
        if (isPaused)
        {
            // Mostrar panel de pausa
            if (settingsPanel) settingsPanel.SetActive(false);
            if (pausePanel) pausePanel.SetActive(true);
            SelectUI(firstPauseButton);
        }
        else
        {
            if (pausePanel) pausePanel.SetActive(false);
            if (settingsPanel) settingsPanel.SetActive(false);
        }
    }

    void SetPaused(bool value)
    {
        isPaused = value;
        Time.timeScale = isPaused ? 0f : 1f;     // Pausa el juego
        AudioListener.pause = isPaused;          // Pausa audio
        Cursor.visible = isPaused;               // Mostrar cursor
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    void SelectUI(GameObject go)
    {
        if (!go) return;
        EventSystem es = EventSystem.current;
        if (!es) return;
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(go);
    }

    // --- Botones ---
    public void BtnContinue()
    {
        SetPaused(false);
        if (pausePanel) pausePanel.SetActive(false);
        if (settingsPanel) settingsPanel.SetActive(false);
    }

    public void BtnOpenSettings()
    {
        if (!settingsPanel) return;
        if (pausePanel) pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
        SelectUI(firstSettingsButton);
    }

    public void BtnBackFromSettings()
    {
        if (settingsPanel) settingsPanel.SetActive(false);
        if (pausePanel) pausePanel.SetActive(true);
        SelectUI(firstPauseButton);
    }

    public void BtnExit()
    {
        // Antes de salir, quita la pausa para evitar quedarse el timeScale en 0
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(1);
    }
    public void BtnExit2()
    {
        // Antes de salir, quita la pausa para evitar quedarse el timeScale en 0
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }
}

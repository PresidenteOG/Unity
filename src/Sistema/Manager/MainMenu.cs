using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Canva1;        // Menú principal
    public GameObject Canva2;        // Menú de selección de nivel
    public GameObject CanvaConfig;   // Menú de configuración
    public AudioClip Click;          // Sonido al hacer clic

    void Start()
    {
        Cursor.visible = true;                     // Muestra el cursor
        Cursor.lockState = CursorLockMode.None;    // Libera el cursor
    }

    // Muestra el menú de selección de nivel
    public void Starty()
    {
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        Canva1.SetActive(false);
        Canva2.SetActive(true);
    }

    // Abre el menú de configuración
    public void Config()
    {
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        Canva1.SetActive(false);
        Canva2.SetActive(false);
        CanvaConfig.SetActive(true);
    }

    // Carga el nivel 1
    public void Nivel1()
    {
        RunBall.I.ResetRun();
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        SceneManager.LoadScene(3);
    }

    // Carga el nivel 2
    public void Nivel2()
    {
        RunBall.I.ResetRun();
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        SceneManager.LoadScene(4);
    }

    // Carga el nivel 3
    public void Nivel3()
    {
        RunBall.I.ResetRun();
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        SceneManager.LoadScene(5);
    }

    // Vuelve al menú principal
    public void Volver()
    {
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        Canva1.SetActive(true);
        Canva2.SetActive(false);
        CanvaConfig.SetActive(false);
    }

    // Sale al menú inicial (escena 0)
    public void Exit()
    {
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        SceneManager.LoadScene(0);
    }
}

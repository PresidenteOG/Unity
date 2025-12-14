using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class HeadMenu : MonoBehaviour
{
    public AudioClip Click;  // Sonido al hacer clic en un botón

    // Carga la escena 1
    public void Select1()
    {
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        SceneManager.LoadScene(1);
    }

    // Carga la escena 2
    public void Select2()
    {
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        SceneManager.LoadScene(2);
    }

    // Cierra el juego
    public void Select3()
    {
        AudioSource.PlayClipAtPoint(Click, transform.position, 1f);
        Application.Quit();
    }
}

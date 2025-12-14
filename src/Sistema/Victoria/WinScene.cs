using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
    void Start()
    {
        // Llama a la función LoadMainMenu después de 3 segundos
        Invoke("LoadMainMenu", 3);
    }

    void LoadMainMenu()
    {
        // Carga la escena del menú principal
        SceneManager.LoadScene("MainMenu");
    }
}

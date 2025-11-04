using UnityEngine;
using TMPro;

public class Tiempo : MonoBehaviour
{
    public TMP_Text timerText; // Texto donde se mostrará el tiempo
    float time;                // Contador interno

    void Update()
    {
        // Suma el tiempo transcurrido cada frame
        time += Time.deltaTime;

        // Convierte los segundos en minutos y segundos
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        // Muestra el tiempo en formato mm:ss
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}

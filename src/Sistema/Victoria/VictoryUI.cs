using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text turnsText;

    public int menuIndex = 0; // tu menu principal

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (VictoryData.isBall)
        {
            timeText.text = "Tiempo: " + RunBall.I.GetTimeText();
            turnsText.text = "Turnos: " + RunBall.I.turns;
        }
        else
        {
            timeText.text = "Tiempo: " + RunTerrain.I.GetTimeText();
            turnsText.text = "Turnos: " + RunTerrain.I.turns;
        }
    }

    public void Reintentar()
    {
        if (VictoryData.isBall)
        {
            RunBall.I.ResetRun();
            SceneManager.LoadScene(3); // inicio BallRunner
        }
        else
        {
            RunTerrain.I.ResetRun();
            SceneManager.LoadScene(2); // inicio Freeway
        }
    }

    public void Siguiente()
    {
        if (VictoryData.nextIndex < 0) return;

        if (VictoryData.isBall) RunBall.I.ResetRun();
        else RunTerrain.I.ResetRun();

        SceneManager.LoadScene(VictoryData.nextIndex);
    }

    public void Menu()
    {
        if (RunBall.I != null) Object.Destroy(RunBall.I.gameObject);
        if (RunTerrain.I != null) Object.Destroy(RunTerrain.I.gameObject);

        SceneManager.LoadScene(menuIndex);
    }
}

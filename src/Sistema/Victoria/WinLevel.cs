using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        int current = SceneManager.GetActiveScene().buildIndex;
        int next = current + 1;

        // BallRunner: niveles seguidos, Victoria es la 6
        if (next >= 6)
        {
            // Último nivel → Victoria
            VictoryData.isBall = true;   // BallRunner
            VictoryData.retryIndex = current;
            VictoryData.nextIndex = -1;

            SceneManager.LoadScene(6);
        }
        else
        {
            // Aún quedan niveles
            SceneManager.LoadScene(next);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            if (RunBall.I != null)
                RunBall.I.AddTurn();

            if (RunTerrain.I != null)
                RunTerrain.I.AddTurn();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

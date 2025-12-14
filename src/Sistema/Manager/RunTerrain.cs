using UnityEngine;
using UnityEngine.SceneManagement;

public class RunTerrain : MonoBehaviour
{
    public static RunTerrain I;

    public float time;
    public int turns; // intentos

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
        ResetRun();
    }

    void Update()
    {
        time += Time.deltaTime;
    }

    public void ResetRun()
    {
        time = 0f;
        turns = 1; // el primer intento cuenta como 1
    }

    public void AddTurn()
    {
        turns++;
    }

    public string GetTimeText()
    {
        int m = Mathf.FloorToInt(time / 60f);
        int s = Mathf.FloorToInt(time % 60f);
        return $"{m:00}:{s:00}";
    }
}

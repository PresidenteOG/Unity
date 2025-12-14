using UnityEngine;

public class RunBall : MonoBehaviour
{
    public static RunBall I; // Instancia única

    public float time; // Tiempo total
    public int turns;  // Intentos

    void Awake()
    {
        // Singleton
        if (I != null)
        {
            Destroy(gameObject);
            return;
        }

        I = this;
        DontDestroyOnLoad(gameObject);
        ResetRun();
    }

    void Update()
    {
        // Cuenta el tiempo del nivel
        time += Time.deltaTime;
    }

    // Reinicia datos
    public void ResetRun()
    {
        time = 0f;
        turns = 1;
    }

    // Aumenta el contador de intentos
    public void AddTurn()
    {
        turns++;
    }

    // Devuelve el tiempo en texto
    public string GetTimeText()
    {
        int m = Mathf.FloorToInt(time / 60f);
        int s = Mathf.FloorToInt(time % 60f);
        return $"{m:00}:{s:00}";
    }
}

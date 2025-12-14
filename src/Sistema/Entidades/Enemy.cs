using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;   // Controla el movimiento del enemigo
    private Transform playerTransform;   // Posición del jugador

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();           // Obtiene el NavMeshAgent
        playerTransform = FindAnyObjectByType<Jugador>().transform;  // Busca al jugador
    }

    void Update()
    {
        navMeshAgent.destination = playerTransform.position;   // Persigue al jugador
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))          // Si toca al jugador
        {
            RunBall.I.AddTurn();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena
        }
    }
}

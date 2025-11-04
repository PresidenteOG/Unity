using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float speed = 5f;   // Velocidad del jugador
    private Rigidbody rb;      // Referencia al Rigidbody

    void Awake()
    {
        rb = GetComponent<Rigidbody>();  // Obtiene el Rigidbody del jugador
    }

    void Update()
    {
        // Detecta movimiento con teclas (WASD o flechas)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Crea un vector de movimiento según la entrada del jugador
        Vector3 movement = new Vector3(moveHorizontal * speed, rb.linearVelocity.y, moveVertical * speed);

        // Aplica el movimiento al Rigidbody
        rb.linearVelocity = movement;
    }
}

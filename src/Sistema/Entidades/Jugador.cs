using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector3(
            h * speed,
            rb.linearVelocity.y,
            v * speed
        );
    }
}

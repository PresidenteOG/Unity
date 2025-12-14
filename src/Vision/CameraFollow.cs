using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // El objeto a seguir (ej: el Player)
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset;        // Distancia/posición relativa de la cámara respecto al target

    void LateUpdate()
    {
        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = target.position + offset;

        // Interpola suavemente entre la posición actual y la deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Aplica la posición final a la cámara
        transform.position = smoothedPosition;

        // Opcional: hacer que la cámara siempre mire al objeto
        //transform.LookAt(target);
    }
}

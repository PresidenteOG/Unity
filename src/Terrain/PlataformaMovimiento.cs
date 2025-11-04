using UnityEngine;
using System.Collections;

public class PlataformaMovimiento : MonoBehaviour
{
    public float yAbajo = 78f;   // Posición mínima (abajo)
    public float yArriba = 135f; // Posición máxima (arriba)
    public float velocidad = 3f; // Velocidad de movimiento
    public float espera = 3f;    // Tiempo de espera entre movimientos

    void Start()
    {
        // Inicia la rutina que mueve la plataforma continuamente
        StartCoroutine(MoverPlataforma());
    }

    IEnumerator MoverPlataforma()
    {
        while (true)
        {
            // Baja la plataforma
            yield return MoverA(yAbajo);
            yield return new WaitForSeconds(espera);

            // Sube la plataforma
            yield return MoverA(yArriba);
            yield return new WaitForSeconds(espera);
        }
    }

    IEnumerator MoverA(float yObjetivo)
    {
        Vector3 pos = transform.position;

        // Mueve la plataforma suavemente hacia el valor Y objetivo
        while (Mathf.Abs(transform.position.y - yObjetivo) > 0.01f)
        {
            pos.y = Mathf.MoveTowards(transform.position.y, yObjetivo, velocidad * Time.deltaTime);
            transform.position = pos;
            yield return null; // Espera al siguiente frame
        }
    }
}

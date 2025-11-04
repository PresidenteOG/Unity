using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class EmissionPulseMPB : MonoBehaviour
{
    public Color baseEmissionColor = Color.yellow;  // Color base de emisión
    public float minIntensity = 2.5f;               // Intensidad mínima
    public float maxIntensity = 3f;                 // Intensidad máxima
    public float speed = 1f;                        // Velocidad del pulso

    private Renderer rend;                          // Referencia al renderer
    private MaterialPropertyBlock mpb;              // Bloque de propiedades del material

    void Awake()
    {
        rend = GetComponent<Renderer>();            // Obtiene el renderer del objeto
        mpb = new MaterialPropertyBlock();          // Crea el bloque de propiedades

        // Activa la emisión en el material
        if (rend.sharedMaterial != null)
            rend.sharedMaterial.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);          // Crea un ciclo entre 0 y 1
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, t); // Interpola la intensidad
        Color emission = baseEmissionColor * Mathf.LinearToGammaSpace(intensity); // Calcula el color final

        rend.GetPropertyBlock(mpb);                 // Obtiene el bloque actual
        mpb.SetColor("_EmissionColor", emission);   // Cambia el color de emisión
        rend.SetPropertyBlock(mpb);                 // Aplica el nuevo valor al material
    }
}

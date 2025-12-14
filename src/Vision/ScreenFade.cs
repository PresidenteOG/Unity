using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;           // Imagen que cubre la pantalla
    public float fadeDuration = 1.5f; // Duración del fundido

    void Awake()
    {
        if (fadeImage == null)
            fadeImage = GetComponent<Image>();

        // Inicia la pantalla completamente negra
        fadeImage.color = new Color(0, 0, 0, 1);
    }

    void Start()
    {
        // Comienza el efecto de fundido
        StartCoroutine(FadeIn());
    }

    System.Collections.IEnumerator FadeIn()
    {
        float t = 0f;
        Color color = fadeImage.color;

        // Reduce la opacidad hasta desaparecer
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1f - (t / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Asegura que quede totalmente transparente y desactiva la imagen
        fadeImage.color = new Color(color.r, color.g, color.b, 0);
        fadeImage.gameObject.SetActive(false);
    }
}

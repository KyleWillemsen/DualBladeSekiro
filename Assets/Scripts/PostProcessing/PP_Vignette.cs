using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PP_Vignette : MonoBehaviour
{
    public static PP_Vignette instance;
    public Volume volume;
    public UnityEngine.Rendering.Universal.Vignette vignette;
    float vignetteBase;
    [Header("Colours")]
    [SerializeField] private Color baseColour;
    public Color parryColour;
    public Color soulColour;
    public Color black;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        volume.profile.TryGet(out vignette);
        vignetteBase = vignette.intensity.value;
    }

    public void StartVignette(float maxStrength, float speed, float duration, Color colour)
    {
        StartCoroutine(Vignette(maxStrength, speed, duration, colour));
    }

    private IEnumerator Vignette(float maxStrength, float speed, float duration, Color colour)
    {
        float t = Time.unscaledTime;
        while (Time.unscaledTime < t + duration)
        {
            vignette.color.value = colour;
            vignette.intensity.value += speed * Time.unscaledDeltaTime;
            if (vignette.intensity.value >= maxStrength)
            {
                vignette.intensity.value = maxStrength;
            }
            yield return null;
        }
        EndVignette();
    }

    public void EndVignette()
    {
        StopAllCoroutines();
        vignette.color.value = baseColour;
        vignette.intensity.value = vignetteBase;
    }
}

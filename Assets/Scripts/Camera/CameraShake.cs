using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraShake : MonoBehaviour
{
    //References
    public static CameraShake instance;
    
    //Camera Follow
    Transform camPos;
    Vector3 originalLocalPosition;
    float shakeDelay;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(instance);
        camPos = Camera.main.transform;
    }

    private void Start()
    {
        originalLocalPosition = camPos.localPosition;
    }

    private void Update()
    {
        if (shakeDelay > 0) shakeDelay -= Time.deltaTime;
    }

    public void StartShake(float duration, float maxMagnitude)
    {
        if (duration < shakeDelay) return;

        shakeDelay = duration;
        StartCoroutine(Shake(duration, maxMagnitude));
    }

    private IEnumerator Shake(float duration, float maxMagnitude)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float percentComplete = elapsed / duration;
            float damping = 1f - percentComplete; //Linear fade off

            float x = Random.Range(-1f, 1f) * maxMagnitude * damping;
            float y = Random.Range(-1f, 1f) * maxMagnitude * damping;

            camPos.localPosition = originalLocalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }
        camPos.localPosition = originalLocalPosition;
    }
}

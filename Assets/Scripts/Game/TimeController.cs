using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;
    [HideInInspector] public float hitStopDuratiuon;
    [HideInInspector] public float hitStopStrength;
    [HideInInspector] public bool hitstop;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(instance);
    }

    public void StartHitstop(float duration, float strength)
    {
        hitStopDuratiuon = duration;
        hitStopStrength = strength;
        StartCoroutine(Hitstop());
    }

    public IEnumerator Hitstop()
    {
        Time.timeScale = hitStopStrength;
        yield return new WaitForSecondsRealtime(hitStopDuratiuon);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{

    public Light sun;
    public Light[] lights;
    public float secondsInFullDay;
    [Range(0, 1)]
    public float timeOfDay = 0;
    public float timeMultiplier;
    public bool canTimeAdvance;

    float initialIntensity;
    float dirLightIntensity;

    // Start is called before the first frame update
    void Start()
    {
        initialIntensity = sun.intensity;
        dirLightIntensity = lights[0].intensity;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSun();

        if (canTimeAdvance)
        {
            AdvanceTime();

            timeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

            if (timeOfDay >= 1)
                timeOfDay = 0;
        }
    }

    void AdvanceTime()
    {
       
        float intensityMultiplier = 1;
        if (timeOfDay <= 0.20f || timeOfDay >= 0.80f)
        {
            intensityMultiplier = 0;
        } else if (timeOfDay <= 0.22f)
        {
            intensityMultiplier = Mathf.Clamp01((timeOfDay - 0.20f) * (1 / 0.02f));
        } else if (timeOfDay >= 0.78f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - (timeOfDay - 0.78f) * (1 / 0.02f));
        }

        sun.intensity = initialIntensity * intensityMultiplier;
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].intensity = dirLightIntensity * intensityMultiplier;
        }
    }

    public void ChangeSun()
    {
        sun.transform.localRotation = Quaternion.Euler((timeOfDay * 360f - 90), 170, 0);
    }
}
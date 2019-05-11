using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{

    public Light sun;
    public float secondsInFullDay;
    [Range(0, 1)]
    public float timeOfDay = 0;
    public float timeMultiplier;

    float initialIntensity;

    // Start is called before the first frame update
    void Start()
    {
        initialIntensity = sun.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        AdvanceTime(0);

        timeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (timeOfDay >= 1)
            timeOfDay = 0;
    }

    void AdvanceTime(float increment)
    {
        sun.transform.localRotation = Quaternion.Euler((timeOfDay * 360f - 90), 170, 0);

        float intensityMultiplier = 1;
        if (timeOfDay <= 0.20f || timeOfDay >= 0.80f)
        {
            intensityMultiplier = 0;
        } else if (timeOfDay <= 0.20f)
        {
            intensityMultiplier = Mathf.Clamp01((timeOfDay - 0.20f) * (1 / 0.02f));
        } else if (timeOfDay >= 0.80f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - (timeOfDay - 0.20f) * (1 / 0.02f));
        }

        sun.intensity = initialIntensity * intensityMultiplier;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{

    public ParticleSystem water;
    ParticleSystem.EmissionModule emissionModule;

    private float rotX;

    // Start is called before the first frame update
    void Start()
    {
        emissionModule = water.emission;
    }

    // Update is called once per frame
    void Update()
    {
        rotX = transform.eulerAngles.x;
        if (rotX < 270 && rotX > 30)
        {
            emissionModule.rateOverTime = ((rotX - -12) / (-90 - 12));
        }
        else
        {
            emissionModule.rateOverTime = 0;
        }
    }
}

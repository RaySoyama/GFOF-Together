using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{

    public ParticleSystem water;
    ParticleSystem.EmissionModule emissionModule;

    // Start is called before the first frame update
    void Start()
    {
        emissionModule = water.emission;
    }

    // Update is called once per frame
    void Update()
    {
        emissionModule.rateOverTime = Mathf.Lerp(0, 75, -transform.rotation.x);
    }
}

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

        //Debug.Log(rotX);
        //-12 to -90
        if (rotX > 270 && rotX < 348f)
        {
            //fuck math big brain too tired
            emissionModule.rateOverTime = 348 - rotX ;
            Debug.Log(emissionModule.rateOverTime);
        }
        else
        {
            emissionModule.rateOverTime = 0;
        }

    }
}

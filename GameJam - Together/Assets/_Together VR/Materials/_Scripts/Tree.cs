using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public DayCycle sun;
    public float growingSpeed;
    public float growAmount;
    public float size;
    public float water;
    public float totalWater;
    public float sunEnergy;
    public float totalEnergy;
    public float sunToGrowthRatio;
    public float waterToGrowthRatio;
    public float growthThreshold;

    // Start is called before the first frame update
    void Start()
    {
        if (waterToGrowthRatio <= 0)
        {
            waterToGrowthRatio = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float growIncrement = 0;
        growIncrement = growIncrement + (water + sunEnergy) * growingSpeed * Time.deltaTime;

        if (sun.timeOfDay >= 0.23f && sun.timeOfDay <= 0.78f)
        {
            sunEnergy = growingSpeed / sunToGrowthRatio;
        }
        else
        {
            sunEnergy = 0;
        }

        if (totalWater > 0)
        {
            growAmount += growIncrement;
            totalWater -= water * Time.deltaTime;
        }

        if (growAmount >= growthThreshold)
        {
            growAmount = 0;

            transform.localScale *= size;
        }
    }
}

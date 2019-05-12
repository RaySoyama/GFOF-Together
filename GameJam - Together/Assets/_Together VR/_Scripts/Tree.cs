using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public WorldManager wm;
    public Renderer myMat;
    public Color wetDirtColor;
    public float growingSpeed;
    public float water;
    public float totalWater;
    public float growthThreshold;

    [SerializeField]
    private float growAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float growIncrement = 0;

        growIncrement = water * growingSpeed * Time.deltaTime;

        if (totalWater > 0)
        {
            growAmount += growIncrement;
            totalWater -= water * Time.deltaTime;
        }

        if (growAmount >= growthThreshold)
        {
            growAmount = 0;
            totalWater = 0;

            SetMaterialColor(wetDirtColor);
            wm.isPlantWatered = true;
        }
    }

    public void SetMaterialColor(Color newColor)
    {
        myMat.material.color = newColor;
    }

    private void OnParticleCollision(GameObject other)
    {
        totalWater += water * Time.deltaTime * 2;
    }
}

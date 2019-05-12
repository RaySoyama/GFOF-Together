using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingPot : MonoBehaviour
{
    public BoxCollider seedCollider;

    bool seedPlanted;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Seed")
        {
            seedPlanted = true;
        }
    }
}

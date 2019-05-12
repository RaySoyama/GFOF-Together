using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingPot : MonoBehaviour
{
    public BoxCollider seedCollider;

    bool seedPlanted;
    public WorldManager worldManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Seed")
        {
            worldManager.isSeedInPot = true;
        }
    }
}

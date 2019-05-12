using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingPot : MonoBehaviour
{
    public Collider seedCollider;
    
    public WorldManager worldManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Seed"))
        {
            worldManager.isSeedInPot = true;
            this.enabled = false;
        }

        if (other == seedCollider)
    }
}

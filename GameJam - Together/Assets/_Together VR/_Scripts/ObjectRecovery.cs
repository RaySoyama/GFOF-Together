using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class entry
{
    public GameObject item;
    public Vector3 returnPoint;
    [HideInInspector]
    public Rigidbody rigidBody;
}

public class ObjectRecovery : MonoBehaviour
{
    public Vector3 smallCorner;
    public Vector3 largeCorner;
    public entry[] objects;
    
    void Start()
    {
        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].rigidBody = objects[i].item.GetComponent<Rigidbody>();
        }
    }


    void Update()
    {
        for(int i = 0; i < objects.Length; i++)
        {
            if (objects[i].item.transform.position.x < smallCorner.x || objects[i].item.transform.position.y < smallCorner.y || objects[i].item.transform.position.z < smallCorner.z
            || objects[i].item.transform.position.x > largeCorner.x || objects[i].item.transform.position.y > largeCorner.y || objects[i].item.transform.position.z > largeCorner.z)
            {
                objects[i].item.transform.position = objects[i].returnPoint;
                objects[i].rigidBody.velocity = Vector3.zero;
                objects[i].rigidBody.angularVelocity = Vector3.zero;
                Debug.Log("Test");
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(smallCorner, 0.1f);
        Gizmos.DrawSphere(largeCorner, 0.1f);
    }
}

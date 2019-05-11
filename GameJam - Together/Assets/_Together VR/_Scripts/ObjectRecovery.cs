using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRecovery : MonoBehaviour
{
    public GameObject[] objects;
    Rigidbody[] rigidBodies;
    
    void Start()
    {
        rigidBodies = new Rigidbody[objects.Length];
        for(int i = 0; i < objects.Length; i++)
        {
            rigidBodies[i] = objects[i].GetComponent<Rigidbody>();
        }

    }


    void Update()
    {
        for(int i = 0; i < objects.Length; i++)
        {
            if (objects[i].transform.position.y < 0)
            {
                Vector3 newPos = new Vector3(objects[i].transform.position.x, 1, objects[i].transform.position.z);
                objects[i].transform.position = newPos;
                rigidBodies[i].velocity = Vector3.zero;
            }
        }
    }
}

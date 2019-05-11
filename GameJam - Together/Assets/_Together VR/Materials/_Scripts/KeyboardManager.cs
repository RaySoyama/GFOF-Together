using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    public GameObject oculusPrefab;
    public Vector3 defaultStartLocation;

    public DigitalRuby.RainMaker.RainScript rainScript;

    void Start()
    {
      
    }

    void Update()
    {


        if (Input.GetKeyUp(KeyCode.R))
        {
            oculusPrefab.transform.position = defaultStartLocation;
        }
        


    }
}

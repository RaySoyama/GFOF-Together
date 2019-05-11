using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    public GameObject oculusPrefab;
    public DigitalRuby.RainMaker.RainScript rainScript;

    void Start()
    {
      
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.R))
        {
            oculusPrefab.transform.position = Vector3.zero;
        }
        


    }
}

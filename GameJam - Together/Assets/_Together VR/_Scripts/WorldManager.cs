﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public enum GameState
    {
        StartMenu,
        SeedPre,
        Seed,
        Sapling,
        GrowthOne,
        GrowthTwo,
        GrowthThree,
        GrowthFour,
        GrowthFive,
        EndScene,
        EndMenu
    }

    [Header("References")]
    public OVRScreenFade OculusCenterCamera;
    public GameObject oculusPlayerController;
    public DayCycle dayCycle;

    public Vector3 theVoid;

    [Header("Plants n shit")]
    //plants
    public GameObject plantpot;
    public GameObject seededPot;
    public Animator saplingTree;
    public GameObject treeGrowthOne;
    public GameObject treeGrowthTwo;
    public GameObject treeGrowthThree;
    public GameObject treeGrowthFour;
    public GameObject treeGrowthFive;


    public GameState startingGameState = GameState.StartMenu;
    public Vector3 startingPos;

    [ReadOnlyField]
    public GameState currentGameState;
    [ReadOnlyField]
    public bool isSeedInPot = false;
    [ReadOnlyField]
    public bool isSeedGrabedFirst = false;
    [ReadOnlyField]
    public bool isPlantWatered = false;


    void Start()
    {
        currentGameState = startingGameState;
        isSeedInPot = false;
        isSeedGrabedFirst = false;
        isPlantWatered = false;

        if (currentGameState == GameState.StartMenu)
        {
            oculusPlayerController.transform.position = startingPos;

            seededPot.transform.position = theVoid;
            //treeGrowthOne.transform.position = theVoid;
            //treeGrowthTwo.transform.position = theVoid;
            //treeGrowthThree.transform.position = theVoid;
            //treeGrowthFour.transform.position = theVoid;
            //treeGrowthFive.transform.position = theVoid;

        }

    }

    void Update()
    {

        switch (currentGameState)
        {
            case GameState.StartMenu:

                dayCycle.timeOfDay = 0.5f;
                dayCycle.canTimeAdvance = false;

                //StartingScene as for now, press K to skip
                if (Input.GetKeyUp(KeyCode.P))
                {
                    StartCoroutine(InitializeScene());
                }

                break;

            case GameState.SeedPre:

                if (isSeedGrabedFirst == true)
                {
                    currentGameState = GameState.Seed;
                }

                break;

            case GameState.Seed:
                dayCycle.canTimeAdvance = true;

                if (isSeedInPot == true)
                {
                    if (plantpot.transform.position != theVoid)
                    {
                        seededPot.transform.position = plantpot.transform.position;
                        seededPot.transform.rotation = plantpot.transform.rotation;
                        seededPot.transform.localScale = plantpot.transform.localScale;

                        plantpot.transform.position = theVoid;
                        plantpot.SetActive(false);
                    }

                    if (dayCycle.timeOfDay >= 0.8f || dayCycle.timeOfDay <= 0.2f)
                    {
                        dayCycle.canTimeAdvance = false;

                        if (isPlantWatered == true)
                        {
                            dayCycle.canTimeAdvance = true;

                            //Start growing the tree
                            saplingTree.SetBool("Grow", true);

                            currentGameState = GameState.Sapling;
                        }
                    }
                    
                }

                if (Input.GetKeyUp(KeyCode.P))
                {
                    isPlantWatered = true;
                }
                
                break;
            case GameState.Sapling:
                break;
            case GameState.GrowthOne:
                break;
            case GameState.GrowthTwo:
                break;
            case GameState.GrowthThree:
                break;
            case GameState.GrowthFour:
                break;
            case GameState.GrowthFive:
                break;
            case GameState.EndScene:
                break;
            case GameState.EndMenu:
                break;
            default:
                break;
        }




    }


    public IEnumerator  InitializeScene()
    {
        currentGameState = GameState.SeedPre;
        StartCoroutine(OculusCenterCamera.Fade(0.0f, 1.0f));

        //yield return new WaitForSeconds(3.0f);
        yield return new WaitForEndOfFrame();

        dayCycle.timeOfDay = 0.0f;
        //change shit
        oculusPlayerController.transform.position = new Vector3(0,0,0);
        StartCoroutine(OculusCenterCamera.Fade(1.0f, 0.0f));

    }
}
    
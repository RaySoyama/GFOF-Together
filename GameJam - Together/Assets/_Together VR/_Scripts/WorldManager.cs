using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public enum GameSate
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

    public GameSate startingGameState = GameSate.StartMenu;

    [ReadOnlyField]
    public GameSate currentGameState;
    [ReadOnlyField]
    public bool isSeedInPot = false;



    public float transtitionBlackscreenDuration;

    void Start()
    {
        currentGameState = startingGameState;
        isSeedInPot = false;
    }

    void Update()
    {

        switch (currentGameState)
        {
            case GameSate.StartMenu:

                //StartingScene as for now, press K to skip
                if (Input.GetKeyUp(KeyCode.K))
                {
                    currentGameState = GameSate.Seed;
                }
                break;
            case GameSate.SeedPre:
                //make sene dark
                //daycyle shit make day stop transition

                //make 
                

                break;

            case GameSate.Seed:

                break;
            case GameSate.Sapling:
                break;
            case GameSate.GrowthOne:
                break;
            case GameSate.GrowthTwo:
                break;
            case GameSate.GrowthThree:
                break;
            case GameSate.GrowthFour:
                break;
            case GameSate.GrowthFive:
                break;
            case GameSate.EndScene:
                break;
            case GameSate.EndMenu:
                break;
            default:
                break;
        }




    }


    public IEnumerator  InitializeScene()
    {
        StartCoroutine(OculusCenterCamera.Fade(1.0f, 0.0f));

        yield return new WaitForSeconds(OculusCenterCamera.fadeTime);

        //change shit
        oculusPlayerController.transform.position = Vector3.zero;
       
        OculusCenterCamera.FadeOut();
        currentGameState = GameSate.SeedPre;

    }
}

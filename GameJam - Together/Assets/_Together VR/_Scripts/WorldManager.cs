using System.Collections;
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

    public GameState startingGameState = GameState.StartMenu;
    public Vector3 startingPos;

    [ReadOnlyField]
    public GameState currentGameState;
    [ReadOnlyField]
    public bool isGameStarted = false;
    [ReadOnlyField]
    public bool isSeedInPot = false;
    [ReadOnlyField]
    public bool isSeedGrabedFirst = false;
    public GameObject menu;



    public float transtitionBlackscreenDuration;

    void Start()
    {
        currentGameState = startingGameState;
        isSeedInPot = false;
        isSeedGrabedFirst = false;

        if (currentGameState == GameState.StartMenu)
        {
            oculusPlayerController.transform.position = startingPos;
        }

    }

    void Update()
    {

        switch (currentGameState)
        {
            case GameState.StartMenu:

                dayCycle.canTimeAdvance = false;
                dayCycle.timeOfDay = 0.5f;

                //StartingScene as for now, press K to skip
                if (Input.GetKeyUp(KeyCode.P))
                {
                    currentGameState = GameState.Seed;
                }

                break;
            case GameState.SeedPre:

                dayCycle.timeOfDay = 0.0f;

                //when seed is first touched
                if(Input.GetKeyUp(KeyCode.L))
                {
                    currentGameState = GameState.Seed;
                }

                break;

            case GameState.Seed:
                dayCycle.canTimeAdvance = true;



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
        StartCoroutine(OculusCenterCamera.Fade(1.0f, 0.0f));

        yield return new WaitForSeconds(OculusCenterCamera.fadeTime);

        //change shit
        oculusPlayerController.transform.position = Vector3.zero;
       
        OculusCenterCamera.FadeOut();
        currentGameState = GameState.SeedPre;

    }

    public void startGame()
    {
        isGameStarted = true;
        menu.SetActive(false);
    }
}

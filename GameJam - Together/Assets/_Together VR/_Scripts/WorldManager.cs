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
    public Tree saplingTreeScript;

    public Vector3 theVoid;

    [Header("Anim")]
    public Animator saplingTreeAnim;
    public Animator seededTreeAnim;
    public Animator fairyAnim;

    [Header("Plants n shit")]
    //plants
    public GameObject seedGameObject;
    public GameObject plantpot;
    public GameObject seededPot;
    public GameObject treeGrowthOne;
    public GameObject treeGrowthTwo;
    public GameObject treeGrowthThree;
    public GameObject treeGrowthFour;
    public GameObject treeGrowthFive;


    public GameState startingGameState = GameState.StartMenu;
    public Vector3 startingPos;
    public Vector3 TreeGrowthOnePos;
    public Vector3 TreeGrowthTwoPos;
    public Vector3 TreeGrowthThreePos;
    public Vector3 TreeGrowthFourPos;
    public Vector3 TreeGrowthFivePos;

    [Header("OVR controller")]
    public OVRInput.Controller leftController;
    public OVRInput.Controller rightController;

    [ReadOnlyField]
    public GameState currentGameState;
    [ReadOnlyField]
    public bool isGameStarted = false;
    [ReadOnlyField]
    public bool isSeedGrabedFirst = false;
    [ReadOnlyField]
    public bool isSeedInPot = false;
    [ReadOnlyField]
    public bool isPlantWatered = false;
    [ReadOnlyField]
    public bool garbageRunning = false;

    public GameObject menu;
    public GameObject credits;

    void Start()
    {
        currentGameState = startingGameState;
        isSeedInPot = false;
        isSeedGrabedFirst = false;
        isPlantWatered = false;

        garbageRunning = false;

        //oculusPlayerController.GetComponent<CharacterController>().isTrigger = true;

        if (currentGameState == GameState.StartMenu)
        {
            oculusPlayerController.transform.position = startingPos;

            seededPot.transform.position = theVoid;
            treeGrowthOne.transform.position = theVoid;
            treeGrowthTwo.transform.position = theVoid;
            treeGrowthThree.transform.position = theVoid;
            treeGrowthFour.transform.position = theVoid;
            treeGrowthFive.transform.position = theVoid;

            seededPot.SetActive(true);
            treeGrowthOne.SetActive(false);
            treeGrowthTwo.SetActive(false);
            treeGrowthThree.SetActive(false);
            treeGrowthFour.SetActive(false);
            treeGrowthFive.SetActive(false);

            credits.SetActive(false);
        }

    }

    void Update()
    {

        switch (currentGameState)
        {
            case GameState.StartMenu:

                dayCycle.timeOfDay = 0.5f;
                dayCycle.canTimeAdvance = false;
                    
                if(Input.GetKeyDown(KeyCode.P))
                {
                    StartCoroutine(InitializeScene());
                }

                Debug.Log(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, rightController));
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, rightController) >= 0.1f || OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, leftController) >= 0.1f)
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
                    if (plantpot.gameObject.activeSelf != false)
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
                            dayCycle.timeOfDay = 0.2f;
                            //Start growing the tree
                            saplingTreeAnim.SetBool("Grow", true);
                            saplingTreeScript.SetMaterialColor(Color.white);
                            isPlantWatered = false;
                            currentGameState = GameState.Sapling;
                            break;
                        }
                    }
                    seedGameObject.transform.position = theVoid;
                    seedGameObject.gameObject.SetActive(false);
                }
                
                break;
            case GameState.Sapling:
                if (isPlantWatered == true)
                {

                    if (dayCycle.timeOfDay >= 0.8f || dayCycle.timeOfDay <= 0.2f)
                    {
                        if(garbageRunning == false)
                        { 
                            StartCoroutine(LiteralGarbage());
                            garbageRunning = true;
                        }
                    }
                }
                break;
            case GameState.GrowthOne:

                if (dayCycle.timeOfDay > 0.85f)
                {
                    treeGrowthOne.transform.position = theVoid;
                    treeGrowthOne.SetActive(false);

                    treeGrowthTwo.transform.position = TreeGrowthTwoPos;
                    treeGrowthTwo.SetActive(true);

                    dayCycle.timeOfDay = 0.15f;
                    currentGameState = GameState.GrowthTwo;
                }

                break;
            case GameState.GrowthTwo:

                if (dayCycle.timeOfDay > 0.85f)
                {
                    treeGrowthTwo.transform.position = theVoid;
                    treeGrowthTwo.SetActive(false);

                    treeGrowthThree.transform.position = TreeGrowthThreePos;
                    treeGrowthThree.SetActive(true);

                    dayCycle.timeOfDay = 0.15f;
                    currentGameState = GameState.GrowthThree;
                }

                break;
            case GameState.GrowthThree:


                if (dayCycle.timeOfDay > 0.85f)
                {
                    treeGrowthThree.transform.position = theVoid;
                    treeGrowthThree.SetActive(false);

                    treeGrowthFour.transform.position = TreeGrowthFourPos;
                    treeGrowthFour.SetActive(true);

                    dayCycle.timeOfDay = 0.15f;
                    currentGameState = GameState.GrowthFour;
                }

                break;
            case GameState.GrowthFour:

                if (dayCycle.timeOfDay > 0.85f)
                {
                    treeGrowthFour.transform.position = theVoid;
                    treeGrowthFour.SetActive(false);

                    treeGrowthFive.transform.position = TreeGrowthFivePos;
                    treeGrowthFive.SetActive(true);

                    dayCycle.timeOfDay = 0.15f;
                    currentGameState = GameState.GrowthFive;
                }


                break;
            case GameState.GrowthFive:

                StartCoroutine(DeathTimer());

                break;
            case GameState.EndScene:
                break;
            case GameState.EndMenu:
                break;
            default:
                break;
        }

    }

    public IEnumerator LiteralGarbage()
    {

        fairyAnim.SetBool("Activate Fairy", true);

        dayCycle.timeOfDay = 0.8f;
        dayCycle.canTimeAdvance = true;

        yield return new WaitForSeconds(4.5f);
        
        dayCycle.timeOfDay = 0.1f;

        dayCycle.canTimeAdvance = false;

        yield return new WaitForSeconds(5.0f);

        seededTreeAnim.SetBool("Lift Plant", true);

        //when anim done, make day time,
        yield return new WaitForSeconds(7.0f);

        fairyAnim.SetBool("Activate Fairy", false);

        yield return new WaitForSeconds(2.0f);


        treeGrowthOne.SetActive(true);
        treeGrowthOne.transform.position = TreeGrowthOnePos;

        seededPot.transform.position = theVoid;
        //seededPot.gameObject.SetActive(false);
        Destroy(seededPot);

        dayCycle.timeOfDay = 0.2f;
        dayCycle.canTimeAdvance = true;

        dayCycle.timeMultiplier = 3.5f;
        currentGameState = GameState.GrowthOne;
    }

    public IEnumerator  InitializeScene()
    {
        currentGameState = GameState.SeedPre;
        StartCoroutine(OculusCenterCamera.Fade(0.0f, 1.0f));

        isGameStarted = true;
        //yield return new WaitForSeconds(3.0f);
        yield return new WaitForSeconds(2.0f);

        menu.SetActive(false);
        dayCycle.timeOfDay = 0.0f;
        //change shit
        oculusPlayerController.transform.position = new Vector3(0,1,0);
        StartCoroutine(OculusCenterCamera.Fade(1.0f, 0.0f));
    }

    public IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(10.0f);
        StartCoroutine(OculusCenterCamera.Fade(0.0f, 1.0f));
        yield return new WaitForSeconds(2.0f);
        oculusPlayerController.transform.position = startingPos;

        StartCoroutine(OculusCenterCamera.Fade(1.0f, 0.0f));

        credits.SetActive(true);

        currentGameState = GameState.EndMenu;
        //cadetunrthis object on

    }
}
    
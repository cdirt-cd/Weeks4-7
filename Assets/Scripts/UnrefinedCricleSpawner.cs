using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnrefinedCricleSpawner : MonoBehaviour
{
    public Slider healthbarSlider;

    //variables for health bar management
    public float maxHealth = 100;
    public float minHealth;
    private float currentHealth;
    private float damage = 10f;

    //GameObject class so the script knows what to instantiate
    public GameObject prefabUnrefinedCircle;

    private GameObject spawnedUnrefinedCircle;

    //scrapped list
    //public List<GameObject> unrefinedCircles = new List<GameObject>();

    //GameObject class so the script knows what to instantiate
    public GameObject  prefabRefinedCircle;

    private GameObject spawnedRefinedCircle;


    //RefinerButton class so the script can access its transform.position
    RefinerButton refinerButton;

    //RefinedCircleSpawnLocation class so the refinedCircles spawn where I want them to
    RefinedCircleSpawnLocation refinedCircleSpawnLocation;

    //float for the distance between the unrefinedCircle and the refinerButton that is acceptable for the unrefinedCircle to be refined
    private float clickableRadius = 1f;

    //camera class for converting world coordinates to screen coordinates
    private Camera gameCamera;

    DamageArea damageArea;

    private float damageDistance = 1f;

    private bool buttonPressed = false;

    public GameObject gameOver;



    void Start()
    {
     

        //initialization of the camera to the main camera in the scene
        gameCamera = Camera.main;

        //insatiation of an unrefinedCircle on start
        spawnedUnrefinedCircle = Instantiate(prefabUnrefinedCircle, transform.position, Quaternion.identity);

        //initialization of the refinerButton and refinedCircleSpawnLocation so the script can access their transform.position
        refinerButton = FindObjectOfType<RefinerButton>();

        refinedCircleSpawnLocation = FindObjectOfType<RefinedCircleSpawnLocation>();

        damageArea = FindObjectOfType<DamageArea>();

        //code for the script to know what the inital health is
        currentHealth = maxHealth;
        healthbarSlider.value = currentHealth / maxHealth;

        //spawnedObjects { spawnedObject[0] }


        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

      
        //screenspace stuff for transform things
        Vector3 refinerPositionInScreenSpace = gameCamera.WorldToScreenPoint(refinerButton.transform.position);
        Vector3 refinedCircleSpawnPositionInScreenSpace = gameCamera.WorldToScreenPoint(refinedCircleSpawnLocation.transform.position);

        //Vector3 damageArea = new Vector3(-2.71f, -1.32f, 0.05537571f);

        if (spawnedUnrefinedCircle == null)//this checks to see if there is a unrefinedCircle, of there isn't it runs the code below
        {
            //this instantiates a new unrefinedCircle
            spawnedUnrefinedCircle = Instantiate(prefabUnrefinedCircle, transform.position, Quaternion.identity);
           
        }

        //Old code that was gonna be used for handling the destruction of unrefined circles 
        //if (refinerButton != null)
        //{
        //    Vector3 spawnedUnrefinedCirclePos = spawnedUnrefinedCircle.transform.position;
        //    Vector3 refinerPos = refinerButton.transform.position;


        //    //float distanceBetween = Vector3.Distance(spawnedUnrefinedCirclePos, refinerPos);

        //    if (Vector3.Distance(spawnedUnrefinedCirclePos, refinerPos) <= clickableRadius)
        //    {

        //        destroyDistance = true;



        //    }


        //    if (buttonClicked == true && destroyDistance == true)
        //    {
        //        Destroy(spawnedUnrefinedCircle);
        //        buttonClicked = false;
        //        destroyDistance = false;
        //        // Reset the distance check after destroying
        //    }


        //    //Debug.Log("Distance Between: " + distanceBetween);
        //    //Debug.Log("Button Clicked: " + buttonClicked);
        //    //Debug.Log("Spawned Unrefined Circle Position: " + spawnedUnrefinedCirclePos);

        //    Debug.Log("destroyDistance: " + destroyDistance);
        //}


        //if the button isn't seen as pressed this code runs
        if (buttonPressed == false)
        {
            //Vector3 stuff for Vector3.Distance shenanigans
            Vector3 spawnedUnrefinedCirclePos = spawnedUnrefinedCircle.transform.position;
            Vector3 damageAreaPos = damageArea.transform.position;

            //if the unrefinedCircle is within the damageArea it runs the code below
            if (Vector3.Distance(spawnedUnrefinedCirclePos, damageAreaPos) <= damageDistance)//This checks where the unrefinedCircle is in relation to the refiner
                                                                              //then if it is within refiner it runs the code below
            {
                //Destroys the unrefinedCircle and the player takes damage
                Destroy(spawnedUnrefinedCircle);
                currentHealth -= damage;
                healthbarSlider.value = currentHealth / maxHealth;

            }

            //Debug.Log("Distance Between: " + Vector3.Distance(spawnedUnrefinedCirclePos, damageAreaPos));
        }
        
        //code for game over screen
        if(currentHealth <= 0)
        {
            //sets game over text to active
            gameOver.SetActive(true);

           //freezes the game
           Time.timeScale = 0f;

        }




    }

    public void OnClick()
    {
        //code for refining the unrefined circle when the refiner button is clicked and the unrefined circle is within the refiner
        if (refinerButton != null) //this checks if the refiner button has been pressed and runs the code below
        {
            //this code is for setting up Vector3.Distance stuff
            Vector3 spawnedUnrefinedCirclePos = spawnedUnrefinedCircle.transform.position;
            Vector3 refinerPos = refinerButton.transform.position;

            //old variable that I scrapped due to being obsolete
            //float distanceBetween = Vector3.Distance(spawnedUnrefinedCirclePos, refinerPos);


            if (Vector3.Distance(spawnedUnrefinedCirclePos, refinerPos) <= clickableRadius)//This checks where the unrefinedCircle is in relation to the refiner
                                                                                           //then if it is within refiner it runs the code below
            {
                //this destroys the UnrefinedCircle
                Destroy(spawnedUnrefinedCircle);
                //this spawns in a refinedCircle
                spawnedRefinedCircle = Instantiate(prefabRefinedCircle, refinedCircleSpawnLocation.transform.position, Quaternion.identity);

            }
            

                //bool variables, set to true when button pressed and then set to false after so that the button is seen as still pressed
                buttonPressed = true;
            buttonPressed = false;
        }
    }
    public void OnHealthChanged() //debugging code to see if the health bar is working
    {
        Debug.Log("Health has changed" + healthbarSlider.value.ToString());
    }


}

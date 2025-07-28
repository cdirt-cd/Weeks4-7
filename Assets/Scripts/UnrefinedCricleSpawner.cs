using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnrefinedCricleSpawner : MonoBehaviour
{
    //GameObject class so the script knows what to instantiate
    public GameObject prefabUnrefinedCircle;

    private GameObject spawnedUnrefinedCircle;

    //public List<GameObject> unrefinedCircles = new List<GameObject>();

    public GameObject  prefabRefinedCircle;

    private GameObject spawnedRefinedCircle;



    RefinerButton refinerButton;

    RefinedCircleSpawnLocation refinedCircleSpawnLocation;

    private float clickableRadius = 1f;


    private Camera gameCamera;


    void Start()
    {
        //Instantiate the unrefinedCircle at the position of this GameObject on start
        //Instantiate(unrefinedCircle, transform.position, Quaternion.identity);

        gameCamera = Camera.main;
        spawnedUnrefinedCircle = Instantiate(prefabUnrefinedCircle, transform.position, Quaternion.identity);
        refinerButton = FindObjectOfType<RefinerButton>();
        refinedCircleSpawnLocation = FindObjectOfType<RefinedCircleSpawnLocation>();


        //spawnedObjects { spawnedObject[0] }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 refinerPositionInScreenSpace = gameCamera.WorldToScreenPoint(refinerButton.transform.position);
        Vector3 refinedCircleSpawnPositionInScreenSpace = gameCamera.WorldToScreenPoint(refinedCircleSpawnLocation.transform.position);



        if (spawnedUnrefinedCircle == null)
        {
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

    }

    public void OnClick()
    {
        //When a button is clicked this code runs
        //To make sure that this code only runs
        if (refinerButton != null)
        {
            Vector3 spawnedUnrefinedCirclePos = spawnedUnrefinedCircle.transform.position;
            Vector3 refinerPos = refinerButton.transform.position;


            //float distanceBetween = Vector3.Distance(spawnedUnrefinedCirclePos, refinerPos);

            if (Vector3.Distance(spawnedUnrefinedCirclePos, refinerPos) <= clickableRadius)
            {

                Destroy(spawnedUnrefinedCircle);

                spawnedRefinedCircle = Instantiate(prefabRefinedCircle, refinedCircleSpawnLocation.transform.position, Quaternion.identity);

            }



        }
    }

}

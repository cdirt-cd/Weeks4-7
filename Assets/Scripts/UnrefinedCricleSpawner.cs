using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnrefinedCricleSpawner : MonoBehaviour
{
    //GameObject class so the script knows what to instantiate
    public GameObject prefabUnrefinedCircle;

    private GameObject spawnedUnrefinedCircle;

    public List<GameObject> unrefinedCircles = new List<GameObject>();


    void Start()
    {
        //Instantiate the unrefinedCircle at the position of this GameObject on start
        //Instantiate(unrefinedCircle, transform.position, Quaternion.identity);


        spawnedUnrefinedCircle = Instantiate(prefabUnrefinedCircle, transform.position, Quaternion.identity);

        //spawnedObjects { spawnedObject[0] }

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedUnrefinedCircle == null)
        {
            spawnedUnrefinedCircle = Instantiate(prefabUnrefinedCircle, transform.position, Quaternion.identity);
           
        }


    }
}

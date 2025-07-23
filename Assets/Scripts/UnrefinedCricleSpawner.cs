using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnrefinedCricleSpawner : MonoBehaviour
{
    public GameObject unrefinedCircle;



    void Start()
    {
        GetComponent<GameObject>();

        Instantiate(unrefinedCircle, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

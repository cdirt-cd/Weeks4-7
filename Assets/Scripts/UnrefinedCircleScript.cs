using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnrefinedCircleScript : MonoBehaviour
{
    //Speed class which determines how fast the circle will be going
    private float speed = 1f;
    //Camera class for getting the main camera to convert world coordinates to screen coordinates for the circle to make sure it
    //moves properly
    private Camera gameCamera;
    //Direction class which determines the direction the circle will be moving which will be to the right
    private float direction = 1f; 

    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;

        //(for if i do this)speed = speed * speedSlider.value * squaresDestroyed * Time.deltaTime; 
    }

    // Update is called once per frame
    void Update()
    {
        //Code that converts the Circle's transform.position to screen space
        Vector3 unrefinedCirclePositionInScreenSpace = gameCamera.WorldToScreenPoint(transform.position);

        //Makes the circle move to the right at a constant speed multiplied by Time.deltaTime to make sure it is frame rate independent
        Vector3 pos = transform.position;
        pos.x += direction * speed * Time.deltaTime;
        transform.position = pos;



    }
}

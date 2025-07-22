using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlipMover : MonoBehaviour
{
    private float direction = 1f;
    private float speed = 1f;
    private bool buttonClicked = false;
    private Camera  gameCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameCamera = Camera.main;

        Vector3 squarePositionInScreenSpace = gameCamera.WorldToScreenPoint(transform.position);

        if (buttonClicked == true)
        {
            Vector3 pos = transform.position;

            pos.x += direction * speed * Time.deltaTime;



            transform.position = pos;
        }
    }

    public void OnMoveClick()
    {
        buttonClicked = true;
                               
    }


    public void OnStopClick() { buttonClicked = false; }

    public void OnFlipClick()
    {
        direction *= -1f;
    }
}

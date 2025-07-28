using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrusherScript : MonoBehaviour
{
    private float speed = 1f;
    private float direction = -1f;

    private bool crusherActive = false;

    private Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 crusherPositionInScreenSpace = gameCamera.WorldToScreenPoint(transform.position);

        if (crusherActive)
        {
            direction = -1f;
            Vector3 pos = transform.position;
            pos.y += direction * speed * Time.deltaTime;
            transform.position = pos;

            if(transform.position.y <= 0.85f) 
            {
                crusherActive = false;
                direction = 1f;
                pos.y += direction * speed * Time.deltaTime;
                transform.position = pos;

                if (crusherActive == false)

                {
                    direction = 0f;
                }
            }

          

        }
        

    }


    public void OnClick()
    {
        crusherActive = true; 
    }
}

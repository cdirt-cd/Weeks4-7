using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CrusherScript : MonoBehaviour
{
    private float speed = 1f;
    //private float direction = -1f;

    private bool crusherActive = false;
    // private bool defaultPosition = true;
    private float beginning = 2.7612f;
    private float end = 0.86f;

    private Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 pos = transform.position;
        //pos.y += direction * speed * Time.deltaTime;

        Vector3 start = transform.position;
        Vector3 target = new Vector3(2.91f, 0.85f, 0f);
        Vector3 directionToMove = target - start;

        Vector3 crusherPositionInScreenSpace = gameCamera.WorldToScreenPoint(transform.position);
        transform.position = transform.position + directionToMove * speed * Time.deltaTime;
        
            
        if (transform.position.y <= end)
        {
            crusherActive = false;
            directionToMove = start - target; 
            transform.position = transform.position + directionToMove * speed * Time.deltaTime;

           

        }  
            
           

        
        



    }


    public void OnClick()
    {
        crusherActive = true; 
    }
}

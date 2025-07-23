using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefinerButton : MonoBehaviour
{
    private bool buttonClicked = false;
    public GameObject unrefinedCircle;
    List<GameObject> unrefinedCircles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //GameObject spawnedUnrefinedCircle = Instantiate(unrefinedCircle);
        //unrefinedCircles.Add(spawnedUnrefinedCircle);
    }

    // Update is called once per frame
    void Update()
    {
       if(buttonClicked == true)
        {
            Destroy(unrefinedCircle);
        }
    }



    public void OnClick()
    {
        buttonClicked = true;
    }
}

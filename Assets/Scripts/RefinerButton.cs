using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefinerButton : MonoBehaviour
{
    private bool buttonClicked = false;
    public GameObject unrefinedCircle;
    public List<GameObject> unrefinedCircles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        //GameObject spawnedUnrefinedCircles = Instantiate(unrefinedCircle);
        //unrefinedCircles.Add(spawnedUnrefinedCircles);

        //GetComponent<UnrefinedCricleSpawner>().unrefinedCircles;
    }

    // Update is called once per frame
    void Update()
    {
       if(buttonClicked == true)
        {
            //Destroy(spawnedUnrefinedCircles);
        }
    }



    public void OnClick()
    {
        buttonClicked = true;
    }
}

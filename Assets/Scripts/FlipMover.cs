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

    public AudioSource moveClickAudioSource;
    public AudioSource flipClickAudioSource;
    public AudioSource stopClickAudioSource;

    public AudioClip stopClickAudioClip;

    public List<AudioClip> flipClickAudioClips;



    void Start()
    {
        stopClickAudioSource.clip = stopClickAudioClip;
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
        moveClickAudioSource.Play();                       
    }


    public void OnStopClick() 
    {
        buttonClicked = false; 
        stopClickAudioSource.Play();
    }

    public void OnFlipClick()
    {
        direction *= -1f;
        //flipClickAudioSource.Play();
        //make sure you are taking into account the exclusive nature of the maximum parameter with random.range
        int randomIndex = UnityEngine.Random.Range(0, flipClickAudioClips.Count);
        AudioClip randomlyChosenClip = flipClickAudioClips[randomIndex];

        flipClickAudioSource.PlayOneShot(randomlyChosenClip);

    }
}

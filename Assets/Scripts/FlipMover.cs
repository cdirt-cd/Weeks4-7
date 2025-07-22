using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FlipMover : MonoBehaviour
{
    private float direction = 1f;
    private float speed = 2f;
    public float maxStamina = 100;
    public float minHealth;
    private float currentStamina;
    public float exhaustion;

    private bool buttonClicked = false;

    private Camera  gameCamera;

    public AudioSource moveClickAudioSource;
    public AudioSource flipClickAudioSource;
    public AudioSource stopClickAudioSource;

    public AudioClip stopClickAudioClip;

    public List<AudioClip> flipClickAudioClips;

    public Slider staminaBarSlider;

    public Image staminaBarImage;

    

   



    void Start()
    {
        stopClickAudioSource.clip = stopClickAudioClip;

       

        currentStamina = maxStamina;

        staminaBarSlider.value = currentStamina / maxStamina;

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

        if(buttonClicked == true)
        {
            currentStamina = currentStamina - 5f * Time.deltaTime;

            staminaBarSlider.value = currentStamina / maxStamina;


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

    public void StaminaGoingDown()
    {
        if (staminaBarSlider.value == 0)
        {
            speed = speed / 2;

            //stamineBarImage.color = Color.red;
        }
    }

}

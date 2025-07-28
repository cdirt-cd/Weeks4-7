using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public Slider healthbarSlider;

    public float maxHealth = 100;
    public float minHealth;
    private float currentHealth;
    private float damage = 10f;


    void Start()
    {
        currentHealth = maxHealth;

        healthbarSlider.value = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnDamageClick()
    //{

    //    currentHealth -= damage;
    //    healthbarSlider.value = currentHealth / maxHealth;
    //}

    public void OnHealthChanged()
    {
        Debug.Log("Health has changed" + healthbarSlider.value.ToString());
    }
}

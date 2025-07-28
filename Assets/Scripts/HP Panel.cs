//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class HPPanel : MonoBehaviour
//{
//    public Slider healthbarSlider;

//    public float maxHealth = 100;
//    public float minHealth;
//    private float currentHealth;
//    public float damage;

//    public GameObject prefabUnrefinedCircle;

//    private GameObject spawnedUnrefinedCircle;

//    // Start is called before the first frame update
//    void Start()
//    {
//        currentHealth = maxHealth;

//        healthbarSlider.value = currentHealth / maxHealth;
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }


//    public void OnDamageClick()
//    {

//        currentHealth -= damage;
//        healthbarSlider.value = currentHealth / maxHealth;
//    }

//    public void OnHealthChanged()
//    {
//        Debug.Log("Health has changed" + healthbarSlider.value.ToString());
//    }


//}

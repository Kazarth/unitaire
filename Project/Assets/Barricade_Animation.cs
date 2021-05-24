using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barricade_Animation : MonoBehaviour
{
    public float healthPool = 100;
    public float currentCollisionCount = 0;
    private float attackMultiplier = 0;
    [SerializeField] Slider barricadeHealthSlider;

    private void OnCollisionEnter(Collision collision)
    {

        currentCollisionCount++;
        attackMultiplier += 0.5f;
    }

    void update(){
        barricadeHealthSlider.value = healthPool;
    }

    private void OnCollisionStay(Collision collision)
    {

        healthPool = healthPool - attackMultiplier;
        barricadeHealthSlider.value = healthPool;
        if (healthPool == 0)

        {
            Destroy(GameObject.FindWithTag("Barricade"));
        }

    }
}




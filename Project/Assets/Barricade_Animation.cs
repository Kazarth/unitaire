using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Barricade_Animation : MonoBehaviour
{
    public float healthPool = 100;
    public float currentCollisionCount = 0;
    private float attackMultiplier = 0;
    [SerializeField] Slider barricadeHealthSlider;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Image image;
    [SerializeField] GameObject barricadeObject;

    private void OnCollisionEnter(Collision collision)
    {

        currentCollisionCount++;
        attackMultiplier += 0.01f;
    }

    private void OnCollisionStay(Collision collision)
    {

        healthPool = healthPool - attackMultiplier;
        barricadeHealthSlider.value = healthPool;
        if (healthPool <= 0)

        {
            Destroy(GameObject.FindWithTag("Barricade"));
            gameOverCanvas.gameObject.SetActive(true);
            barricadeObject.SetActive(false);
            fadeImage();
        }
    }

    private void fadeImage(){
        for(float i = 0; i <= 1f; i += 0.001f){
            image.color = new Color(1, 1, 1, i);
            Debug.Log(i);
        }
    }
}

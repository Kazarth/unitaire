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
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Image image;
    [SerializeField] GameObject barricadeObject;
    private float fadeRate = 0.01f;
    private float targetAlpha = 1f;

    

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
        Debug.Log("FadeImage lololol");
        for(float i = 0; i <= 1.0f; i += Time.deltaTime){
            image.color = new Color(1, 1, 1, i);
        }
    }
}

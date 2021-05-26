using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barricade_Animation : MonoBehaviour {
  public float healthPool = 100;
  public float currentCollisionCount = 0;
  private float attackMultiplier = 0;
  [SerializeField] Slider barricadeHealthSlider;
  [SerializeField] Canvas gameOverCanvas;
  [SerializeField] Image image;
  [SerializeField] GameObject barricadeObject;
	public GameObject effect;

	public void Start() {
		effect.SetActive(false);
    
	}

	private void Update() {
    if (healthPool <= 0) {
      GameObject[] barricade = GameObject.FindGameObjectsWithTag("Barricade");

			foreach (GameObject go in barricade) {
				go.SetActive(false);
			}

      //Destroy(GameObject.FindWithTag("Barricade"));
      gameOverCanvas.gameObject.SetActive(true);
      barricadeObject.SetActive(false);

      for(float i = 0; i <= 1f; i += 0.001f){
        image.color = new Color(1, 1, 1, i);
      }

			effect.SetActive(true);
    }
	}

  private void OnCollisionEnter(Collision collision) {
    currentCollisionCount++;
    attackMultiplier += 0.01f;
  }

  private void OnCollisionStay(Collision collision) {
    healthPool = healthPool - attackMultiplier;
    barricadeHealthSlider.value = healthPool;
  }

	private void OnCollisionExit(Collision collision) {
		currentCollisionCount--;
		attackMultiplier -= 0.01f;
	}
}

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
	private bool handleEnd;
	private float alpha;

	public void Start() {
		effect.SetActive(false);
		handleEnd = false;
		alpha = 0f;
	}

	private void Update() {
    if (healthPool <= 0 && alpha < 1.0f) {
			alpha += 0.1f;
      image.color = new Color(1, 1, 1, alpha);
			//Debug.Log(alpha);
    }
		
		if (healthPool <= 0 && !handleEnd) {
			effect.SetActive(true);
			
      GameObject[] barricade = GameObject.FindGameObjectsWithTag("Barricade");
			foreach (GameObject go in barricade) {
				go.SetActive(false);
			}
			
      gameOverCanvas.gameObject.SetActive(true);
			(gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;
      barricadeObject.SetActive(false);

			handleEnd = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Barricade_Animation : MonoBehaviour {
  public float healthPool = 100;
  public float currentCollisionCount = 0;
  private float attackMultiplier = 0;
  [SerializeField] Slider barricadeHealthSlider;
	public GameObject gameOverCanvas;
  [SerializeField] Image image;
  [SerializeField] GameObject barricadeHUD;
	public GameObject effect;
	private bool endHandled = false;
	private float alpha = 0;
	//public GameObject trigger;
		
	public void Start() {
		effect.SetActive(false);
		gameOverCanvas.SetActive(false);
	}
		
	private void Update() {
		if (healthPool <= 0 && !endHandled) {
			effect.SetActive(true);
			
			GameObject[] barricade = GameObject.FindGameObjectsWithTag("Barricade");
			foreach (GameObject go in barricade) {
				go.SetActive(false);
			}
			
      barricadeHUD.SetActive(false);
			gameOverCanvas.SetActive(true);
			
			endHandled = true;
		}
		
		
    if (healthPool <= 0 && alpha < 1f) {
			alpha += 0.01f;
			image.color = new Color(1, 1, 1, alpha);
			Debug.Log(alpha);
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

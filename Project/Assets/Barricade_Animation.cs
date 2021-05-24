using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barricade_Animation : MonoBehaviour {
    public float healthPool = 100;
    public float currentCollisionCount = 0;
    private float attackMultiplier = 0;
    [SerializeField] Slider barricadeHealthSlider;
		private GameObject[] explosion;
		public GameObject effect;
		public bool showEffect;
		
		public void Start() {
			explosion = GameObject.FindGameObjectsWithTag("Explosion");
			foreach (GameObject go in explosion) {
				go.SetActive(false);
			}
		}
		
		private void Update() {
			if (showEffect) {
				effect.SetActive(true);
			} else {
				effect.SetActive(false);
			}
			
      if (healthPool <= 0) {
				GameObject[] barricade = GameObject.FindGameObjectsWithTag("Barricade");
				foreach (GameObject go in barricade) {
					go.SetActive(false);
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
}

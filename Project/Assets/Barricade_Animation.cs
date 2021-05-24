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
		//private Transform explosion;
		
		
		public void Start() {
			explosion = GameObject.FindGameObjectsWithTag("Explosion");
			foreach (GameObject go in explosion) {
				go.SetActive(false);
			}
		}
		

    private void OnCollisionEnter(Collision collision) {
        currentCollisionCount++;
        attackMultiplier += 0.01f;
    }

    private void OnCollisionStay(Collision collision) {
        healthPool = healthPool - attackMultiplier;
        barricadeHealthSlider.value = healthPool;
        if (healthPool <= 0) {
						GameObject[] barricade = GameObject.FindGameObjectsWithTag("Barricade");
						foreach (GameObject go in barricade) {
							go.SetActive(false);
						}
						
						/*
						//GameObject[] explosion = GameObject.FindGameObjectsWithTag("Explosion");
						foreach (GameObject go in explosion) {
							go.SetActive(true);
						}
						*/
						//Instantiate(explosion);
        }
    }
}

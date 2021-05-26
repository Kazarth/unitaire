using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUpdate : MonoBehaviour
{

    public float score = 0;
    private float finalScore;
    public TextMeshProUGUI scoreDisplay;
    public bool gameOver = false;
    public GameObject barricade;
    public GameObject scoreUpdater; 

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        zombiesKilledUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        zombiesKilledUpdate();
        setGameOver();
    }

    public void AddScore(){
            if(!gameOver){
            float amount = Time.deltaTime;
            score += amount;
        }
    }

    private void zombiesKilledUpdate(){
        AddScore();
        scoreDisplay.text = score.ToString("F0");    
    }
    public void setGameOver(){
        if(!barricade.activeSelf){
            gameOver = true;
            this.scoreUpdater.SetActive(false);
        }
    }
}

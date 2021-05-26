using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreUpdate : MonoBehaviour
{

    public float score = 0;
    public TextMeshProUGUI scoreDisplay;
    //[SerializeField] Text killedAmount;

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
    }

    public void AddScore(){
        float amount = Time.deltaTime;
        score += amount;
    }

    private void zombiesKilledUpdate(){
        AddScore();
        scoreDisplay.text = score.ToString("F0");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreUpdate : MonoBehaviour
{

    public float zombiesKilled = 0;
    [SerializeField] Text killedAmount;

    // Start is called before the first frame update
    void Start()
    {
        zombiesKilled = 0;
        zombiesKilledUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float amount){
        zombiesKilled += amount;
        zombiesKilledUpdate();
    }

    private void zombiesKilledUpdate(){
        killedAmount.text = zombiesKilled.ToString("0");
    }
}

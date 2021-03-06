using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LightAdjuster : MonoBehaviour
{

    public Light myLight;
    
    //Range variables
    public bool changeRange = false;
    public float rangeSpeed = 1.0f;
    public float maxRange = 10.0f;

    //Intensity variables
    public bool changeIntensity = false;
    public float intensitySpeed = 0.025f;
    public float maxIntensity = 1f;

    //Color variables
    public bool changeColors = false;
    public float colorSpeed = 0.025f;
    public Color startColor;
    public Color endColor;

    public float startTime;


    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(changeRange){
            myLight.range = Mathf.PingPong(Time.time * rangeSpeed, maxRange);
        }

        if(changeIntensity){
            myLight.intensity = Mathf.PingPong(Time.time * intensitySpeed, maxIntensity);
        }

        if(changeColors){
            float t = (Mathf.Sin((Time.time - startTime) * colorSpeed));
            myLight.color = Color.Lerp(startColor, endColor, t);
        }
    }
}

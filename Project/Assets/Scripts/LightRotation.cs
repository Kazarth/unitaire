using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{

    public Light myLight;
    public float roatationSpeed = 0.25f;
    public bool changeRoatation = true;
    float rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(changeRoatation){
            myLight.transform.localEulerAngles = new Vector3(Rotation(), 180, 0);
        }
    }
        float Rotation()
    {
        rotation += roatationSpeed * Time.deltaTime;
        if (rotation >= 180f) 
            rotation -= 180f; // this will keep it to a value of 0 to 359.99...
        return changeRoatation ? rotation : -rotation;
    }
}

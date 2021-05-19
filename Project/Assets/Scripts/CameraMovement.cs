using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float yaw = 0;
    float pitch = 0;

 
    void Start()
    {

    }
 
    void Update()
    {   
        yaw -= 2 * Input.GetAxis("Mouse X");
        pitch += 2 * Input.GetAxis("Mouse Y");
        yaw = Mathf.Clamp(yaw, 69f, 90f);
        pitch = Mathf.Clamp(pitch, 10.5f, 23f);

        if(Input.GetMouseButton(1)){
                transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            }
    }
}

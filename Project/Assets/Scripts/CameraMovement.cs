using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
 
     //The speed of the movement
     public float cameraSpeed = 0.5f;
     public float speedofIncrease = 3;
 
     //Min and max-values the camera can move to.
     private float MAX_X = 445;
     private float MIN_X = 444;
   
     
     private float MAX_Y = 51.768f;
     private float MIN_Y = -51.768f;
     
 
     //The current x and y movement of the cursor
     private float Xmouse;
     private float Ymouse;
 
     //Variables for zoom
     float ZoomAmount = 0; //With Positive and negative values
     public float MaxToClamp = 5;
     public float ROTSpeed = 5;
 
 
     void Start()
     {
 
     }
 
     void Update()
     {
 
         Xmouse = Input.GetAxis("Mouse X");
         Ymouse = Input.GetAxis("Mouse Y");
 
         Vector3 v3 = Input.mousePosition;
         v3.z = transform.position.z;
         v3 = Camera.main.ScreenToWorldPoint(v3);
 
         Vector3 newPos = transform.position;
         newPos.x += Xmouse*speedofIncrease;
         newPos.y += Ymouse*speedofIncrease; 
 
         if (newPos.x > MAX_X)
         {
             newPos.x = MAX_X;
         }
         if (newPos.x < MIN_X)
         {
             newPos.x = MIN_X;
         }
 
        
         if (newPos.y > MAX_Y)
         {
             newPos.y = MAX_Y;
         }
         if (newPos.y < MIN_Y)
         {
             newPos.y = MIN_Y;
         }
        
         transform.position = Vector3.Lerp(transform.position, newPos, cameraSpeed * Time.deltaTime);
     }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Vector3 movementDirections;




    public CharacterController controller;  // new

    public float speed = 6f;  // new
    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;




    // Update is called once per frame
    void Update()
    {


        
if (Input.GetKey(KeyCode.UpArrow))
    transform.position += transform.forward * Time.deltaTime * 5;

if (Input.GetKey(KeyCode.DownArrow))
    transform.position -= transform.forward * Time.deltaTime * 2;


if (Input.GetKey(KeyCode.LeftArrow))
    transform.Rotate(new Vector3(0, -10, 0) * Time.deltaTime * 20);

if (Input.GetKey(KeyCode.RightArrow))
    transform.Rotate(new Vector3(0, +10, 0) * Time.deltaTime * 20);


    }
}







// transform.position += transform.forward * Time.deltaTime * 20; 


//   movementDirections.z = Input.GetAxis("left") * Time.deltaTime * 20;
//        float horizontalInput = Input.GetAxis("Vertical") * Time.deltaTime * 20;
//      float zInput =  Input.GetAxis("Vertical") * Time.deltaTime * 20;

//  float verticalInput   = Input.GetAxis("Vertical") * Time.deltaTime * 20;


//      transform.position = transform.position + new Vector3 (horizontalInput, zInput); 
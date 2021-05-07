using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{


    static Animator anim;
    public float speed = 0.5f;
    public float rotationSpeed = 100.0f;



    void Start()
    {
        anim = GetComponent<Animator>(); 
        
    }

  
    void Update()
    {


        float translation = Input.GetAxis("Vertical")  * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);


        ///attacking?1
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("isRunning");
            anim.SetBool("isIdle", false);  // WHne attacking, take em out from the current state.
          
     
        }

        if (translation != 0)
        {
            anim.SetBool("isRunning", true); 
        }
        else
        {
            anim.SetBool("isRunning", false); 
        }
    }
}

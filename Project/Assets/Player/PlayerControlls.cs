using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{


    static Animator anim;
    public float speed = 0;
    public float rotationSpeed = 100.0f;



    private float timeRemaining = 3;
    private bool isBowDrawn;






    void Start()
    {
        anim = GetComponent<Animator>();
        isBowDrawn = false;
    }


    void Update()
    {


        movement();


        if (Input.GetMouseButton(0))
        {
            speed = 0.5f;
            anim.SetBool("isAiming", true);
      
        }


        // Aiming pose 
        if (Input.GetMouseButtonUp(0))
        {
            shootArrow();
            anim.SetBool("isLoaded", false);
        }


        //Idle pose 
        if (!Input.GetMouseButton(0))
        {
            anim.SetBool("isAiming", false);
        }

        // Reload 
        if (anim.GetBool("isLoaded") == false)
        {
            reload();
            anim.SetBool("isLoaded", true); 

        }


    }





    public void movement()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);


        if (Input.GetKey(KeyCode.W))
        {
            speed = 4;
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


    public void shootArrow()
    {

        print("pew pew");
        
    }


    public void reload()
    {

    }

}

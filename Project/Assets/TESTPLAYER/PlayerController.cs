using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 4;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0f; 


    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
        GetInput(); 
    }


    void Movement ()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {

                anim.SetBool("running", true);
                anim.SetInteger("condition", 1);
                moveDirection = new Vector3(0, 0, 1);
                moveDirection *= speed;
                moveDirection = transform.TransformDirection(moveDirection);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("running", false);
                anim.SetInteger("condition", 0);
                moveDirection = new Vector3(0, 0, 0);
            }


        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }


    void GetInput()
    {
        if (controller.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (anim.GetBool("running") == true)
                {
                    anim.SetBool("running", false);
                    anim.SetInteger("condition", 0);
                }
                else if (anim.GetBool("running") == false)
                {
                    Attacking();
                }

            }

        }
    }



    void Attacking ()
    {
        anim.SetBool("attacking", true); 
        anim.SetInteger("condition", 2);
        StartCoroutine(AttackRoutine());
        anim.SetBool("attacking", false); 
    }


    IEnumerator AttackRoutine ()
    {
        yield return new WaitForSeconds(1); 
    }
}

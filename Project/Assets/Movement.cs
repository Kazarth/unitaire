using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Animator anim; 
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    enum states
    {
        Idle,
        Running,
        Attacking,
    };





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotationSpeed, 0);

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("isRunning");  
        } 






    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{


    static Animator anim;
    public float speed = 0;
    public float rotationSpeed = 100.0f;
    private MousePosition mousePosition;


    TerrainCollider terrainCollider;
    Vector3 worldPosition;
    Ray ray;


    // TEST BOW
    public GameObject arrow;

    public float shootForce, upwardForce;   //Arrow force

    //Bow stats
    public float timeBetweenShooting, reloadTime, timeBetweenArrows;
    public int cougerSize, arrowsPerTap;
    public bool allButtonHold;

    private int arrowLeft, bulletsShot;

    //Bools
    bool shooting, readyToshoot, reloading;


    //References
    public Camera mainCam;
    public Transform attackPoint;


    // Graphics
    public GameObject ArrowRelease;
    public TextMesh arrowDisp; 



    //?

    public bool allowInvoke = true;









    void Start()
    {

        anim = GetComponent<Animator>();
        terrainCollider = Terrain.activeTerrain.GetComponent<TerrainCollider>();

    }


    void Update()
    {


        movement();
        MyInput();



        if (Input.GetMouseButton(0))
        {
            // terrain();
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





    public void Awake()
    {
        arrowLeft = cougerSize;
        readyToshoot = true;
    }



    public void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Draw new Arrow (auto)
        if (readyToshoot && shooting && !reloading && arrowLeft > 0)
        {

        }


        if (readyToshoot && shooting && !reloading && arrowLeft > 0)
        {
            bulletsShot = 0;
            shootArrow();
        }

    }



    public void shootArrow()
    {
        readyToshoot = false;

        arrowLeft--;
        bulletsShot++;

        Ray ray = mainCam.ScreenPointToRay((Input.mousePosition));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;

        else
            targetPoint = ray.GetPoint(50);

        Vector3 targetDirection = targetPoint - attackPoint.position;

        //Instantiate arrow
        GameObject currentArrow = Instantiate(arrow, attackPoint.position, Quaternion.identity);
        currentArrow.transform.forward = targetDirection.normalized;


        //Add force to arrow
        //currentArrow.GetComponent<Rigidbody>().AddForce(targetDirection.normalized * shootForce, ForceMode.Impulse);
        currentArrow.GetComponent<Rigidbody>().AddForce(mainCam.transform.up * upwardForce, ForceMode.Impulse);

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenArrows);
            allowInvoke = false;
        }

    }




    private void ResetShot()
    {
        readyToshoot = true;
        allowInvoke = true;
    }


    public void reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }


    public void ReloadFinished()
    {
        arrowLeft = cougerSize;
        reloading = false; 
    }


}



/**
 * 
 * 
    public void terrain()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;


        if (terrainCollider.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
        }
    }
*/
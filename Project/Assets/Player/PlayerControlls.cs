using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControlls : MonoBehaviour
{


    static Animator anim;
    public float speed = 0;
    public float rotationSpeed = 200.0f;
    private MousePosition mousePosition;


    TerrainCollider terrainCollider;
    Vector3 worldPosition;
    Ray ray;


    // TEST BOW
    public GameObject arrow;

    public float shootForce, upwardForce;   //Arrow force

    //Bow stats
    public float timeBetweenShooting, reloadTime, timeBetweenArrows;
    public int quiverSize, arrowsPerTap;
    public bool allButtonHold;

    private int arrowLeft, bulletsShot;

    //Bools
    bool shooting, readyToshoot, reloading;


    //References
    public Camera mainCam;
    public Transform attackPoint;


    // Graphics
    public GameObject ArrowRelease;
    public TextMeshProUGUI arrowDisp;

    //Fan, tror ja tog vort updates. 


    public bool allowInvoke = true;






    void Start()
    {

        anim = GetComponent<Animator>();
        terrainCollider = Terrain.activeTerrain.GetComponent<TerrainCollider>();

    }


    void Update()
    {

        MyInput();
        movement();



        // Aiming pose 
        if (Input.GetMouseButton(0))
        {
            speed = 0.5f;
            anim.SetBool("isAiming", true);
        }


        //Idle pose 
        if (!Input.GetMouseButton(0))
        {
            anim.SetBool("isAiming", false);
        }


        // Reload 
        //  if (anim.GetBool("isLoaded") == false)
        // {
        ////    reload();
        // anim.SetBool("isLoaded", true);

        //        }

    }





    // Player Movement Inputs 
    public void movement()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);



        //Movement W 
        if (Input.GetKey(KeyCode.W))
        {
            speed = 4;
            anim.SetBool("isIdle", false);

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




    // Start value 
    public void Awake()
    {
        arrowLeft = quiverSize;
        readyToshoot = true;
    }




    // Player Inputs 
    public void MyInput()
    {

        if (arrowDisp != null)
        {
            arrowDisp.SetText(arrowLeft / arrowsPerTap + " / " + quiverSize / arrowsPerTap); 
        }



        shooting = Input.GetKeyUp(KeyCode.Mouse0);

        //Firing Arrow
        if (readyToshoot && shooting && !reloading && arrowLeft >= 0)
        {
            bulletsShot = 0;
            shootArrow();
        }


        //Draw new Arrow (auto)
        if (readyToshoot && shooting && !reloading && arrowLeft >= 0)
        {
            reload();
        }




    }



    public void shootArrow()
    {

        readyToshoot = false;



        Ray ray = mainCam.ScreenPointToRay((Input.mousePosition));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;

        else
            targetPoint = ray.GetPoint(200);


        //Calc direction
        Vector3 targetDirection = targetPoint - attackPoint.position;

        //Instantiate arrow
        GameObject currentArrow = Instantiate(arrow, attackPoint.position, Quaternion.identity);

        //Arrow Rotation 
        currentArrow.transform.forward = targetDirection.normalized;


        //Add force to arrow
        currentArrow.GetComponent<Rigidbody>().AddForce(targetDirection.normalized * shootForce, ForceMode.Impulse);
        currentArrow.GetComponent<Rigidbody>().AddForce(mainCam.transform.up * upwardForce, ForceMode.Impulse);


        arrowLeft--;
        bulletsShot++;


        if (ArrowRelease != null)
        {
            Instantiate(ArrowRelease, attackPoint.position, Quaternion.identity);
        }



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
        arrowLeft = quiverSize;
        reloading = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerControlls : MonoBehaviour {
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
    public GameObject arrowDisp; 

    //?

    public bool allowInvoke = true;

    void Start() {
        anim = GetComponent<Animator>();
        terrainCollider = Terrain.activeTerrain.GetComponent<TerrainCollider>();
    }

    void Update() {
        movement();
        MyInput();

        if (Input.GetMouseButton(0)) {
            // terrain();
            speed = 0.5f;
            anim.SetBool("isAiming", true);
        }

        // Aiming pose 
        if (Input.GetMouseButtonUp(0)) {
            shootArrow();
            anim.SetBool("isLoaded", false);

        }

        //Idle pose 
        if (!Input.GetMouseButton(0)) {
            anim.SetBool("isAiming", false);
        }

        // Reload 
        if (anim.GetBool("isLoaded") == false) {
            reload();
            anim.SetBool("isLoaded", true);
        }
    }

    public void movement() {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKey(KeyCode.W)) {
            speed = 4;
            anim.SetBool("isIdle", false);  // When attacking, take em out from the current state.
        }

        if (translation != 0) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
    }

    public void Awake() {
        arrowLeft = quiverSize;
        readyToshoot = true;
    }

    public void MyInput() {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Firing Arrow
        if (readyToshoot && shooting && !reloading && arrowLeft >= 0) {
            bulletsShot = 0;
            shootArrow();
        }

        //Draw new Arrow (auto)
        if (readyToshoot && shooting && !reloading && arrowLeft >= 0) {
            reload();
        }
    }

    public void shootArrow() {
        readyToshoot = false;

        Ray ray = mainCam.ScreenPointToRay((Input.mousePosition));
        //Ray ray = mainCam.ScreenPointToRay(new Vector3(0.5f, 0.5f,0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit)) {
            targetPoint = hit.point;
        } else {
            targetPoint = ray.GetPoint(200);
				}
				
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

        if (true) {
            Instantiate(ArrowRelease, attackPoint.position, Quaternion.identity); 
        }

        if (allowInvoke) {
            Invoke("ResetShot", timeBetweenArrows);
            allowInvoke = false;
        }
    }

    private void ResetShot() {
        readyToshoot = true;
        allowInvoke = true;
    }

    public void reload() {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    public void ReloadFinished() {
        arrowLeft = quiverSize;
        reloading = false; 
    }
}

/*
    public void terrain() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (terrainCollider.Raycast(ray, out hitData, 1000)) {
            worldPosition = hitData.point;
        }
    }
*/
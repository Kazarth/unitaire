using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{


    TerrainCollider terrainCollider;
    Vector3 worldPosition;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        terrainCollider = Terrain.activeTerrain.GetComponent<TerrainCollider>(); 

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;


        if (terrainCollider.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
            print(worldPosition); 

        }
    }
}

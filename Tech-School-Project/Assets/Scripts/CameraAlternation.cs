using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAlternation : MonoBehaviour
{
    //Lava position
    Transform lava;

    void Start()
    {
        //Lava position
        lava = GameObject.Find("Lava (1)").GetComponent<Transform>();
    }

    void Update()
    {
        //Jump ray
        // RaycastHit2D fireRay = Physics2D.Raycast(cannon_Transform_Top.position, lookDirection.normalized);
        Debug.DrawRay(lava.position, new Vector3(1,0,0), Color.green);
    }
}

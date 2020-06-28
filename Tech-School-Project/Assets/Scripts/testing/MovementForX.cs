using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForX : MonoBehaviour
{
    public GameObject circle;
    void Start()
    {
        
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Input.mousePosition);

        if(hit)
        {
            Debug.DrawLine(Input.mousePosition, transform.position, Color.green);
            Instantiate(circle, hit.point, transform.rotation);
        }
        else
        {
            Debug.DrawLine(Input.mousePosition, transform.position, Color.red);
        }
    }
}

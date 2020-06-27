using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForX : MonoBehaviour
{
    public SpriteRenderer circle;
    void Start()
    {
        
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Input.mousePosition);

        if(hit)
        {
            Debug.DrawLine(transform.position, Input.mousePosition, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, Input.mousePosition, Color.red);
        }
    }
}

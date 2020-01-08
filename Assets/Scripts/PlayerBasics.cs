using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasics : MonoBehaviour
{
    //stairs
    public Transform stairdetect;
    public int lolaso;

    Rigidbody2D rb;
    float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 100;
    }

    void FixedUpdate()
    {
        //Debug.DrawRay(transform.position, transform.right, Color.blue);
        //if (/*RaycastHit2D hit = */Physics2D.Raycast(transform.position, new Vector2(lolaso, 0)).collider)
        //{
        //    print("hit");
        //}

        //Movement
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed *Time.deltaTime * Time.deltaTime, 0, 0);

        //Animation(stairs)
        
        
    }
}

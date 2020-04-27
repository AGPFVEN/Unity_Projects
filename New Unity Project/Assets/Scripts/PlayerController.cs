using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public LayerMask wallMask;
    Rigidbody2D rb;
    Transform cannon_Transform;

    //Reload
    bool jumpReload;

    //Modificable Stats
    float speed;
    public float jumpHeight;

    //Cannon rotation
    Vector2 lookDirection;
    float lookAngle;

    //Cannon top
    Transform cannon_Top;

    void Start()
    {
        //Basic Stuff
        rb = GetComponent<Rigidbody2D>();
        cannon_Transform = transform.GetChild(0);
        cannon_Top = transform.GetChild(0).GetChild(0);

        //Reload
        jumpReload = true;

        //Modificable Stats
        speed = 5f;
        jumpHeight = 2f;
    }
    void FixedUpdate()
    {
        //Horizontal movement
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0);

        //Jump
        jumpReload = Physics2D.OverlapCircle(new Vector2(cannon_Top.position.x, cannon_Top.position.y), 0.05f, wallMask);
        float jInput = Input.GetAxis("Jump");
        if (jumpReload == true && jInput == 1)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }

        //Cannon rotation
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        cannon_Transform.rotation = Quaternion.Euler(0f, 0f, lookAngle + 90f);
    }
}

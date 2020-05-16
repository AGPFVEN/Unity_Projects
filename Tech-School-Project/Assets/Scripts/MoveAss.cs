using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAss : MonoBehaviour
{
    Rigidbody2D rb;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.x > -4.5f)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;

                rb.MoveRotation(90);
                rb.AddForce(new Vector2(-4.5f - transform.position.x, 0).normalized * 25);
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY; 
            }
        }
    }
}
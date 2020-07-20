using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SetHealth : MonoBehaviour
{
    Rigidbody2D rb;
    public float healthset;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthset = 0;
    }
    void Update()
    {
        if(healthset <= -rb.mass)
        {
            healthset = -rb.mass;
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Wall")
        {
            healthset -= 0.5f;
        }
    }
}
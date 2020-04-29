using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Wall")
        {
            healthset -= 0.5f;
        }
    }
}
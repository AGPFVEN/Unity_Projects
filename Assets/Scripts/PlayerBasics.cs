using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasics : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 100;
    }

    void Update()
    {
        //Movement
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed *Time.deltaTime * Time.deltaTime, 0, 0);
    }
}

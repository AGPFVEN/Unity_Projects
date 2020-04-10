using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    //Reload
    float jumpReload;

    //Modificable Stats
    float speed;
    public float jumpHeight;
    void Start()
    {
        //Basic Stuff
        rb = GetComponent<Rigidbody2D>();

        //Reload
        jumpReload = 0;

        //Modificable Stats
        speed = 5f;
        jumpHeight = 3f;
    }
    void FixedUpdate()
    {
        //Horizontal movement
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0);

        //Jump
        float jInput = Input.GetAxis("Jump");
        if (jumpReload <= 0 && jInput == 1)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            jumpReload = 2;
        }
        jumpReload -= 1 * Time.deltaTime;
    }
}

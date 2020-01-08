using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBasics : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rb;
    Transform lastposition;
    Vector2 localmovement;
    float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastposition = target;
        localmovement = new Vector2(10, 0);
        speed = 100;


    }

    void Update()
    {
        //float hInput = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(hInput * speed * Time.deltaTime * Time.deltaTime, 0, 0);
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z - 10);

    }
}

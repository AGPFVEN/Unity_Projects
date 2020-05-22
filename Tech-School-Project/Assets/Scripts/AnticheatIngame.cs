using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnticheatIngame : MonoBehaviour
{
    public bool randomspin;
    public int sign;
    float trap;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, sign * 2 * trap);
        trap -= 1 * Time.deltaTime;

        if (trap <= 0)
        {
            trap = 0;
        }
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if(randomspin == true)
        {
            sign = Random.Range(-1, 2);
            trap += 1;
        }
        if (coll.gameObject.name == "Player")
        {
            trap += 5 * Time.deltaTime;
        }
        else if (coll.gameObject.name != "Player")
        {
            trap -= 1 * Time.deltaTime;
        }

    }
    void OnCollisionExit2D(Collision2D coll)
    {
        trap -= 1 * Time.deltaTime;
    }
}

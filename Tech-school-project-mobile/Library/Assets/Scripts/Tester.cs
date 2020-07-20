using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tester : MonoBehaviour
{
    BoxCollider2D lav;

    void Awake()
    {
        lav = gameObject.GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            Destroy(GameObject.FindWithTag("player"));
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bTLimit = 10f;
    float bTCollider = 100000000000;
    Collider2D aCollider;

    void Start()
    {
        aCollider = GetComponent<Collider2D>();
        aCollider.isTrigger = false;
    }

    void Update()
    {
        //Switch up collider
        if (bTCollider > 0)
        {
            bTCollider--;
            if (bTCollider <= 0)
            {
                aCollider.isTrigger = true;
            }
        }
        //Que pasen 10s
        if (bTLimit > 0)
        {
            bTLimit -= 1 * Time.deltaTime;
            if (bTLimit <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}

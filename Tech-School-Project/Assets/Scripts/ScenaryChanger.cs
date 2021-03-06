﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryChanger : MonoBehaviour
{
    //Set up walls (Transforms)
    Transform wallmini_under_left;
    Transform wallmini_under_right;
    Transform wall_under_left;
    Transform wall_under_right;
    Transform wall_up;
    Transform wall_mid;

    //Set up walls (Rigidbodies)
    Rigidbody2D wallmini_under_left_rb;
    Rigidbody2D wallmini_under_right_rb;
    public Rigidbody2D wall_under_left_rb;
    public Rigidbody2D wall_under_right_rb;
    Rigidbody2D wall_up_rb;

    //Setting up Score
    Interfaz _interfaz_script;
    
    //Wall Killer
    GameObject wall_killer;

    void Awake()
    {
        //Setting up walls (transforms)
        wallmini_under_left = GameObject.Find("Wall (3)").GetComponent<Transform>();
        wallmini_under_right = GameObject.Find("Wall (4)").GetComponent<Transform>();
        wall_under_left = GameObject.Find("Wall").GetComponent<Transform>();
        wall_under_right = GameObject.Find("Wall (1)").GetComponent<Transform>();
        wall_up = GameObject.Find("Wall (5)").GetComponent<Transform>();
        wall_mid = GameObject.Find("Wall (7)").GetComponent<Transform>();

        //Setting up walls (rigidbodies)
        wallmini_under_left_rb = GameObject.Find("Wall (3)").GetComponent<Rigidbody2D>();
        wallmini_under_right_rb = GameObject.Find("Wall (4)").GetComponent<Rigidbody2D>();
        wall_under_left_rb = GameObject.Find("Wall").GetComponent<Rigidbody2D>();
        wall_under_right_rb = GameObject.Find("Wall (1)").GetComponent<Rigidbody2D>();
        wall_up_rb = GameObject.Find("Wall (5)").GetComponent<Rigidbody2D>();

        //Wall killer
        wall_killer = GameObject.Find("Wall killer");

        //Setting
        _interfaz_script = GameObject.Find("Canvas").GetComponent<Interfaz>();

        //Set up ground floor
        wall_mid.localScale = new Vector3(1, 0.05f, 1);
    }

    void FixedUpdate()
    {
        wall_mid.localScale = new Vector3(transform.localScale.x + Time.timeScale, transform.localScale.y, transform.localScale.z);

        if (_interfaz_script.score >= 10 && _interfaz_script.score <= 20)
        {
            if (wallmini_under_left.position.x < 6f)
            {
                wallmini_under_left_rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;

                wallmini_under_left_rb.AddForce
                (
                    new Vector2
                    (
                        6.5f - wallmini_under_left.position.x,
                        -2.6f - wallmini_under_left.position.y
                    ).normalized * 100,
                    ForceMode2D.Force
                );
            }
            else if (wallmini_under_left.position.x >= 6f)
            {
                wallmini_under_left_rb.constraints =
                RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
            }
        }

        if (_interfaz_script.score > 20 && _interfaz_script.score < 30)
        {
            if (wallmini_under_right.position.x <= -6)
            {
                wallmini_under_right_rb.constraints =
                RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
            }
            if (wallmini_under_right.position.x > -6f)
            {
                wallmini_under_right_rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                wallmini_under_right_rb.AddForce
                (new Vector2(-6.2f - wallmini_under_right.position.x, -2.6f - wallmini_under_right.position.y).normalized * 200, ForceMode2D.Force);
            }
        }

        if (_interfaz_script.score >= 30)
        {
            wall_under_right_rb.AddForce(Vector2.up.normalized * 2);
        }
    }
}
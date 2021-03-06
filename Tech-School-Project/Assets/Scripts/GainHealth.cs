﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealth : MonoBehaviour
{
    PlayerController player_script;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-11.5f, 11.5f), Random.Range(-5f, 6f), 0);
        player_script = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            GameObject.Find("Health_bar").GetComponent<Health_Controller>().health_this += 0.25f * 0.325f;
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == "player")
        {
            GameObject.Find("Health_bar").GetComponent<Health_Controller>().health_this += 0.5f * 0.325f;
            Destroy(gameObject);
        }
    }
}

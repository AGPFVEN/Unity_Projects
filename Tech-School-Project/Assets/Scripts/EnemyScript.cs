using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Interfaz spawn_Script;
    PlayerController player_script;
    Health_Controller health_script;
    void Awake()
    {
        spawn_Script = GameObject.Find("Canvas").GetComponent<Interfaz>();
        player_script = GameObject.Find("Player").GetComponent<PlayerController>();
        health_script = GameObject.Find("Health_bar").GetComponent<Health_Controller>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            spawn_Script.score += 1;
            player_script.exp_Float += 0.2f;
            Destroy(gameObject);
        }
        else if (coll.gameObject.tag == "player")
        {
            spawn_Script.score += 1;
            health_script.health_this -= 0.2f * 0.325f;
            player_script.exp_Float += 0.2f / player_script.level;

            Destroy(gameObject);
        }
    }
}

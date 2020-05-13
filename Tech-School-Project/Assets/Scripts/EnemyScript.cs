using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Interfaz spawn_Script;
    PlayerController player_script;
    void Awake()
    {
        spawn_Script = GameObject.Find("Canvas").GetComponent<Interfaz>();
        player_script = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            spawn_Script.score += 1;
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag == "player")
        {
            spawn_Script.score += 1;
            player_script.health_this += 0.2f;
            Destroy(this.gameObject);
        }
    }
}

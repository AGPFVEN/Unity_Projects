using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Spawn spawn_Script;
    void Awake()
    {
        spawn_Script = GameObject.Find("Spawn").GetComponent<Spawn>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        print("hit");
        if (coll.gameObject.tag == "Bullet")
        {
            spawn_Script.score += 1;
            Destroy(this.gameObject);
        }
        else if (coll.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

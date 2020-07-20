using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public ParticleSystem enemydie;
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        ContactPoint2D contact = coll.contacts[0];

        if (coll.gameObject.tag == "Bullet")
        {
            GameObject.Find("Canvas").GetComponent<Interfaz>().score += 1;
            GameObject.Find("Player").GetComponent<PlayerController>().exp_Float += 0.2f;
            // Instantiate()
            Destroy(gameObject);
        }
        else if (coll.gameObject.tag == "player")
        {
            GameObject.Find("Canvas").GetComponent<Interfaz>().score += 1;
            GameObject.Find("Health_bar").GetComponent<Health_Controller>().health_this -= 0.2f * 0.325f;
            GameObject.Find("Player").GetComponent<PlayerController>().exp_Float += 0.2f / GameObject.Find("Player").GetComponent<PlayerController>().level;
            Destroy(gameObject);
        }

        // void dying()
        // {
        // }
    }
}

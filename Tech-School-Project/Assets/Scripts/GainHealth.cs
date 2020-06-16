using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainHealth : MonoBehaviour
{
    PlayerController player_script;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-11.5f, 11.5f), Random.Range(-6.5f, 6.5f), 0);
        player_script = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        // if (coll.gameObject.tag == "Bullet")
        // {
        //     player_script.health_this -= 5 * Time.deltaTime;
        //     Destroy(gameObject);
        // }
        if (coll.gameObject.tag == "player")
        {
            GameObject.Find("Health_bar").GetComponent<Health_Controller>().health_this += 0.5f * 0.325f;
            Destroy(gameObject);
        }
    }
}

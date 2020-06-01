using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Controller : MonoBehaviour
{
    //This
    Transform health_transform;
    Transform powerJump_transform;
    public float health_this = 0.3402343f;
    
    //Reference Player
    Transform player_transform;
    PlayerController player_script;
    
    void Start()
    {
        //Set up transforms
        health_transform = transform.GetChild(1).transform;
        player_transform = GameObject.Find("Player").transform;
        powerJump_transform = transform.GetChild(2).transform;

        //Set up script
        player_script = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //all the bars
        transform.position = new Vector3(player_transform.position.x, player_transform.position.y + 0.83f, 0);

        //Health 
        transform.GetChild(1).transform.localScale = new Vector3(health_this, 0.075689f, 0);
        if(health_this <= 0)
        {
            Destroy(GameObject.Find("Player"));
        }

        //PowerJump
        transform.GetChild(2).transform.localScale = new Vector3((player_script.power_Jump * 0.325f) / 3, 0.28803f, 0);
    }
}

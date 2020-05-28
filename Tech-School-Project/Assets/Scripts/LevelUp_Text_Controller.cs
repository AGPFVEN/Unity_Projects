using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp_Text_Controller : MonoBehaviour
{
    //Player
    Transform player;

    //Delete
    float delete_count;

    void Start()
    {
        //Find player
        player = GameObject.Find("Player").transform;

        //transform.position = new Vector3(player.position.x + UnityEngine.Random.Range(-7, 7) / 10, player.position.y + 0.2f, 0);

        //Destroy
        Destroy(this.gameObject, 1);
    }

    void Update()
    { 
    }
}

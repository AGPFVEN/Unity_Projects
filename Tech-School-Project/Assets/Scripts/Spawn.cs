using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Positions set up
    Vector3 _Spawn_up_left;
    Vector3 _Spawn_up_right;
    Vector3 _Spawn_down_left;
    Vector3 _Spawn_down_right;
    Vector3[] _Spawn_up;
    Vector3[] _Spawn_down;
    float clock;

    //Prefabs set up
    GameObject enemyPrefab_GameObject;
    Rigidbody2D enemy_rb;

    void Awake()
    {
        //Positions declare
        _Spawn_up_left = new Vector3(-11, 8, 0);
        _Spawn_up_right = new Vector3(11, 8, 0);
        _Spawn_down_left = new Vector3(-11, -8, 0);
        _Spawn_down_right = new Vector3(11, -8, 0);

        //Position Array
        _Spawn_up = new Vector3[4];
        _Spawn_down = new Vector3[4];

        //Clock
        clock = 0;

        // enemyPrefab_GameObject = Instantiate
        // (
        //     GameObject.Find("Enemy"), _Spawn_up_left.position, _Spawn_up_left.rotation
        // );

        // enemy_rb= enemyPrefab_GameObject.GetComponent<Rigidbody2D>();
        // enemy_rb.AddForce
        // (
        //     new Vector2
        //     (
        //         (_Spawn_up_right.position.x - _Spawn_up_left.position.x),
        //         (_Spawn_up_right.position.y - _Spawn_up_left.position.y)
        //     ) * 3.5f
        // );
    }
    void Update()
    {
        //Clock Work
        if (clock < 360)
        {
            clock += 2 * Time.deltaTime;
        }
        else if (clock >= 360)
        {
            clock = 0;
        }

        //Spawn Movement
        _Spawn_up_left = new Vector3(11* Mathf.Cos(clock), _Spawn_up_left.y, _Spawn_up_left.z);
        _Spawn_up_right = new Vector3(-11* Mathf.Cos(clock), _Spawn_up_left.y, _Spawn_up_left.z);
        _Spawn_down_left = new Vector3(11* Mathf.Cos(clock), _Spawn_down_left.y, _Spawn_down_left.z);
        _Spawn_down_right = new Vector3(-11* Mathf.Cos(clock), _Spawn_down_right.y, _Spawn_down_right.z);

        _Spawn_up[0] =_Spawn_up_left;
        _Spawn_up[1] =_Spawn_up_right;

        //Define spawn;

        
    }
}

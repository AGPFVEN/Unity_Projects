using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Positions set up
    Vector3[] _Spawn_vectors;
    Vector3 _Spawn_up_vector;
    Vector3 _Spawn_down_vector;

    //Rotación
    float _Angle_Enemy;
    Vector3 _Spawn_Rotation_Vector3;
    Quaternion _Spawn_Rotation;

    //Select Vector y Relojes
    int _Select_spawn_int;
    int _Select_final_int;
    float clock;
    float _Timer_Spawn;

    //Score (connection with Interfaz)
    float score_spawn;

    //Prefabs Enemy set up
    public GameObject enemyPrefab_GameObject;
    GameObject enemy_GameObject;
    Vector3 _Spawn_Direction;

    //Prefabs health giver set up
    public GameObject _healthGiver_Prefab;
    public GameObject _something_Prefab;

    void Awake()
    {
        //Positions declare
        _Spawn_vectors = new Vector3[2];
        _Spawn_vectors[0] = new Vector3(Random.Range(-11, 12), 8, 0);
        _Spawn_vectors[1] = new Vector3(Random.Range(-11, 12), -8, 0);

        //Clocks
        _Timer_Spawn = 0;
    }
    void FixedUpdate()
    {
        //Score
        score_spawn = GameObject.Find("Canvas").GetComponent<Interfaz>().score;

        //Spawn Movement
        _Spawn_vectors[0] = new Vector3(Random.Range(-20, 21), 8, 0);
        _Spawn_vectors[1] = new Vector3(Random.Range(-20, 21), -8, 0);

        //Timer se acabo
        if (_Timer_Spawn >= 1.25f * (1 - (score_spawn / (score_spawn + 10))))
        {
            //Select Spawn
            _Select_spawn_int = Random.Range(0, 2);

            //Define Spawn Quterion
            _Spawn_Rotation_Vector3 = (_Spawn_vectors[Mathf.Abs(_Select_spawn_int - 1)] - _Spawn_vectors[_Select_spawn_int]);
            _Angle_Enemy = Mathf.Atan2(_Spawn_Rotation_Vector3.y, _Spawn_Rotation_Vector3.x) * Mathf.Rad2Deg;
            _Spawn_Rotation = Quaternion.Euler(0f, 0f, _Angle_Enemy - 90);

            //Spawn
            enemy_GameObject = Instantiate
            (
                enemyPrefab_GameObject,  //Original GameObject
                _Spawn_Direction =       //Vector Direction
                (_Spawn_vectors[Mathf.Abs(_Select_spawn_int - 1)] - _Spawn_vectors[_Select_spawn_int]),
                _Spawn_Rotation          //Quaternion Angle
            );

            //Move
            if (score_spawn <= 5)
            {
                enemy_GameObject.GetComponent<Rigidbody2D>().velocity =
                -_Spawn_Direction * 5 * Time.deltaTime;
            }
            else if (score_spawn > 5)
            {
                enemy_GameObject.GetComponent<Rigidbody2D>().velocity =
                -_Spawn_Direction * score_spawn * Time.deltaTime;
            }

            //Timer reset
            _Timer_Spawn = 0;
        }

        //Timer not enough
        else if (_Timer_Spawn < 1.5f * (1 - (score_spawn / (score_spawn + 10))))
        {
            _Timer_Spawn += 1 * Time.deltaTime;
        }
    }
}
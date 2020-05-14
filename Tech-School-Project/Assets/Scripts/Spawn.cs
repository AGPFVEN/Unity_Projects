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

    //Array de Vectores
    Vector3[] _Spawn_up;
    Vector3[] _Spawn_down;

    //Vectores solución
    Vector3 _Spawn_select_start;
    Vector3 _Spawn_select_final;

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
    Interfaz _canvas_script;

    //Prefabs Enemy set up
    public GameObject enemyPrefab_GameObject;
    GameObject enemy_GameObject;
    Vector3 _Spawn_Direction;
    Rigidbody2D enemy_rb;

    //Prefabs health giver set up
    public GameObject _healthGiver_Prefab;

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

        //Clocks
        clock = 0;
        _Timer_Spawn = 0;

        //Score
        _canvas_script = GameObject.Find("Canvas").GetComponent<Interfaz>();
        score_spawn = _canvas_script.score;
    }
    void FixedUpdate()
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
        _Spawn_up_left = new Vector3(17 * Mathf.Cos(clock), _Spawn_up_left.y, _Spawn_up_left.z);
        _Spawn_up_right = new Vector3(-17 * Mathf.Cos(clock), _Spawn_up_left.y, _Spawn_up_left.z);
        _Spawn_down_left = new Vector3(17 * Mathf.Cos(clock), _Spawn_down_left.y, _Spawn_down_left.z);
        _Spawn_down_right = new Vector3(-17 * Mathf.Cos(clock), _Spawn_down_right.y, _Spawn_down_right.z);

        _Spawn_up[0] = _Spawn_up_left;
        _Spawn_up[1] = _Spawn_up_right;

        _Spawn_up[0] = _Spawn_up_left;
        _Spawn_up[1] = _Spawn_up_right;

        //Timer se acabo 
        if (_Timer_Spawn >= 1) //TODO: DEPENDER DE SCORE
        {
            //Select Spawn
            _Select_spawn_int = Random.Range(0, 2);
            _Select_final_int = Random.Range(0, 2);

            if (_Select_spawn_int == 0)
            {
                //Define Spawn Quterion
                _Spawn_Rotation_Vector3 = (_Spawn_down[_Select_final_int] - _Spawn_up[_Select_spawn_int]);
                _Angle_Enemy = Mathf.Atan2(_Spawn_Rotation_Vector3.y, _Spawn_Rotation_Vector3.x) * Mathf.Rad2Deg;
                _Spawn_Rotation = Quaternion.Euler(0f, 0f, _Angle_Enemy - 90);

                //Spawn
                enemy_GameObject = Instantiate
                (
                    enemyPrefab_GameObject,                     //Original GameObject
                    _Spawn_Direction = new Vector3              //Vector Direction
                    (
                        _Spawn_up[_Select_final_int].x - _Spawn_down[_Select_spawn_int].x,
                        _Spawn_up[_Select_final_int].y - _Spawn_down[_Select_spawn_int].y,
                        _Spawn_up[_Select_final_int].z - _Spawn_down[_Select_spawn_int].z
                    ),
                    _Spawn_Rotation                              //Quaternion Angle
                );
            }
            if (_Select_spawn_int == 1)
            {
                //Define Spawn Quterion
                _Spawn_Rotation_Vector3 = -(_Spawn_down[_Select_final_int] + _Spawn_up[_Select_spawn_int]);
                _Angle_Enemy = Mathf.Atan2(_Spawn_Rotation_Vector3.y, _Spawn_Rotation_Vector3.x) * Mathf.Rad2Deg;
                _Spawn_Rotation = Quaternion.Euler(0f, 0f, _Angle_Enemy - 90);

                //Spawn
                enemy_GameObject = Instantiate
                (
                    enemyPrefab_GameObject,                     //Original GameObject
                    _Spawn_Direction = new Vector3              //Vector Direction
                    (
                        -_Spawn_up[_Select_spawn_int].x + _Spawn_down[_Select_final_int].x,
                        -_Spawn_up[_Select_spawn_int].y + _Spawn_down[_Select_final_int].y,
                        -_Spawn_up[_Select_spawn_int].z + _Spawn_down[_Select_final_int].z
                    ),
                    _Spawn_Rotation                              //Quaternion Angle
                );
            }
            //Move
            if (score_spawn <= 5)
            {
                enemy_GameObject.GetComponent<Rigidbody2D>().velocity =
                -_Spawn_Direction * 5 * Time.deltaTime;
            }
            else if (score_spawn > 100)
            {
                print("x10");
                enemy_GameObject.GetComponent<Rigidbody2D>().velocity =
                -_Spawn_Direction * score_spawn * Time.deltaTime * 10; 
            }
            else if (score_spawn > 50)
            {
                enemy_GameObject.GetComponent<Rigidbody2D>().velocity =
                -_Spawn_Direction * score_spawn * Time.deltaTime * 4; 
            }
            else if (score_spawn > 30)
            {
                enemy_GameObject.GetComponent<Rigidbody2D>().velocity =
                -_Spawn_Direction * score_spawn * Time.deltaTime * 2; 
            }
            else if (score_spawn > 5)
            {
                enemy_GameObject.GetComponent<Rigidbody2D>().velocity =
                -_Spawn_Direction * score_spawn * Time.deltaTime; 
            }
            // else if (score_spawn >)

            //Timer reset
            _Timer_Spawn = 0;

        }
        //Timer not enough
        else if (_Timer_Spawn < 2)
        {
            _Timer_Spawn += 1 * Time.deltaTime;
        }
    }
}
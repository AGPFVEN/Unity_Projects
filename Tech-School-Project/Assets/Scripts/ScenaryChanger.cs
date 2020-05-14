using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryChanger : MonoBehaviour
{
    Transform wallmini_under_left;
    Transform wallmini_under_right;
    Transform wall_under_left;
    Transform wall_under_right;
    Transform wall_up;

    void Start()
    {
        wallmini_under_left = GameObject.Find("Wall (3)").GetComponent<Transform>();
        wallmini_under_right = GameObject.Find("Wall (4)").GetComponent<Transform>();
        wall_under_left = GameObject.Find("Wall (3)").GetComponent<Transform>();
        wall_under_right = GameObject.Find("Wall (3)").GetComponent<Transform>();
        wall_up = GameObject.Find("Wall (3)").GetComponent<Transform>();
    }
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnticheatIngame : MonoBehaviour
{
    ScenaryChanger scenaryscript;
    float trap;
    void Start()
    {
        scenaryscript = GameObject.Find("Spawn").GetComponent<ScenaryChanger>();
    }
    void FixedUpdate()
    {
        if (trap >= 1)
        {
            print("nope");
            
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            trap += 1 * Time.deltaTime;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        trap = 0;
    }
}

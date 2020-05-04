using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    float kk;
    // Start is called before the first frame update
    void Start()
    {
        kk = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            kk += 1 * Time.deltaTime;
        }
        else
        {
            kk = 0;
        }
    }
}

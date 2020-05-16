using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Tester : MonoBehaviour
{
    BoxCollider2D lav;

    void Awake()
    {
        lav = gameObject.GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "player")
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}

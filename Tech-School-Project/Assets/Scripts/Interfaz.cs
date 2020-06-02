using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Interfaz : MonoBehaviour
{
    //This Script
    public int score;

    //This UI
    GameObject score_UI;
    Text score_text;
    GameObject exp_UI;
    Text exp_text;

    //Player
    GameObject player_GO;
    PlayerController player_script;
    void Awake()
    {
        //Left Set Up
        score_UI = transform.GetChild(0).transform.GetChild(0).gameObject;     //Score
        exp_UI = transform.GetChild(0).transform.GetChild(1).gameObject;       //Exp

        //Right Set Up

        //Player set up
        player_GO = GameObject.Find("Player");
        player_script = player_GO.GetComponent<PlayerController>();
    }
    void Update()
    {
        //Score
        score_UI.GetComponent<Text>().text = "Score: " + score.ToString();

        //Exp
        exp_UI.GetComponent<Text>().text = "Level: " + player_script.level;

        if(GameObject.Find("Player") == null)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}

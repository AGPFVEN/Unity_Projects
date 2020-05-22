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
    GameObject powerJump_UI;
    Text powerJump_text;
    GameObject watchJump_UI;
    Text watchJump_text;
    GameObject score_UI;
    Text score_text;

    //Player
    GameObject player_GO;
    PlayerController player_script;
    void Awake()
    {
        //This Set Up
        powerJump_UI = transform.GetChild(0).gameObject; //Power Jump
        watchJump_UI = transform.GetChild(1).gameObject; //Watch 
        score_UI = transform.GetChild(2).gameObject;     //Score

        //Player set up
        player_GO = GameObject.Find("Player");
        player_script = player_GO.GetComponent<PlayerController>();
    }
    void Update()
    {
        //Jump power
        powerJump_UI.GetComponent<Text>().text = "this is your jump power: " + player_script.power_Jump.ToString();

        //Score
        score_UI.GetComponent<Text>().text = "Score: " + score.ToString();

        //Jump Watch
        if (player_script.watch_Jump <= 0)
        {
            watchJump_UI.GetComponent<Text>().text = "Your jump is ready";
        }
        else if (player_script.watch_Jump > 0)
        {
            watchJump_UI.GetComponent<Text>().text = "Your jump is NOT ready";
        }
        if(GameObject.Find("Player") == null)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}

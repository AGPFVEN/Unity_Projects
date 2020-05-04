 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interfaz : MonoBehaviour
{
    //This UI
    GameObject powerJump_UI;
    Text powerJump_text;
    GameObject watchJump_UI;
    Text watchJump_text;

    //Player
    GameObject player_GO;
    PlayerController player_script;
    void Awake()
    {
        //This Set Up
        powerJump_UI = transform.GetChild(0).gameObject; //Power Jump
        powerJump_text = powerJump_UI.GetComponent<Text>();

        watchJump_UI = transform.GetChild(1).gameObject; //Watch 
        watchJump_text = watchJump_UI.GetComponent<Text>();

        //Player set up
        player_GO = GameObject.Find("Player");
        player_script = player_GO.GetComponent<PlayerController>();
    }
    void Update()
    {
        powerJump_text.text = "this is your jump power: " + player_script.power_Jump.ToString();
        watchJump_text.text = "this is your Watch: " + player_script.watch_Jump.ToString();
    }
}

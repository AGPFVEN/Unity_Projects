 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interfaz : MonoBehaviour
{
    //This UI
    GameObject powerJump_UI;
    Text powerJump_text;

    //Player
    GameObject player_GO;
    PlayerController player_script;
    void Awake()
    {
        //This set up
        powerJump_UI = this.transform.GetChild(0).gameObject;
        powerJump_text = powerJump_UI.GetComponent<Text>();
        powerJump_text.text = "Hola";

        //Player set up
        player_GO = GameObject.Find("Player");
        player_script = player_GO.GetComponent<PlayerController>();
    }
    void Update()
    {
        powerJump_text.text = player_script.power_Jump.ToString();
    }
}

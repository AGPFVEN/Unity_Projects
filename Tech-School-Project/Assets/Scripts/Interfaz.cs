﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class Interfaz : MonoBehaviour
{
    //This Script
    public float score;

    //This UI Right
    GameObject score_UI;
    GameObject exp_UI;

    //This UI Left
    GameObject velocity_UI;
    GameObject firerate_UI;
    GameObject givehealth_UI;

    //Player
    GameObject player_GO;
    PlayerController player_script;

    //Initial ModStats values
    float[] initial_Modstats;
    void Awake()
    {
        //Player set up
        player_GO = GameObject.Find("Player");
        player_script = player_GO.GetComponent<PlayerController>();

        //Initial modstats values
        initial_Modstats = new float[player_script.modstats.Length];

        //Left Set Up
        score_UI = transform.GetChild(0).transform.GetChild(0).gameObject;     //Score
        exp_UI = transform.GetChild(0).transform.GetChild(1).gameObject;       //Level

        //Right Set Up
        velocity_UI = transform.GetChild(1).transform.GetChild(0).gameObject;  //Velocity
        firerate_UI = transform.GetChild(1).transform.GetChild(1).gameObject;  //Fire rate
        givehealth_UI = transform.GetChild(1).transform.GetChild(2).gameObject;//Health given
    }
    void Update()
    {
        ///////////////////////////R I G H T///////////////////////////////////////////////
        //Score
        score_UI.GetComponent<Text>().text = "Score: " + score.ToString();

        //Exp
        exp_UI.GetComponent<Text>().text = "Level: " + player_script.level.ToString();

        if (GameObject.Find("Player") == null)
        {
            //WEB UPLOAD
            StartCoroutine(Uploadscore());

            //change scene
            SceneManager.LoadScene("EndGame");
        }

        ////////////////////////////L E F T/////////////////////////////////////////////////
        //Velocity 
        velocity_UI.GetComponent<Text>().text = "Speed: x" + (player_script.modstats[0, 0] / player_script.modstats[0, 1]).ToString("F2");

        //Fire rate
        firerate_UI.GetComponent<Text>().text = "Fire Rate: " + player_script.modstats[1, 0].ToString("F2") + "s";

        //Give Health
        givehealth_UI.GetComponent<Text>().text = player_script.givenhealth.ToString() + " Times";

        if (Input.GetKeyDown(KeyCode.L))
        {
            score++; 
        }
    }
    IEnumerator Uploadscore()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Backend-repository/AGPFVEN/Tech-School-Project_php/save_mark.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

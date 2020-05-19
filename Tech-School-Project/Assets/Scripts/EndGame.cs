using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    //Script del MenuManager
    MenuManager menuManager;

    //Variables actuales 
    string username;
    float userscore;

    //Listas
    string[] usernames;
    float[] userscores;

    //Contador
    int count;

    void Start()
    {
        //Contador
        count = 1;

        //Menumanager
        menuManager = GameObject.Find("SceneManager").GetComponent<MenuManager>();

        //Arrays
        userscores = new float[9];
        usernames = new string[9];

        //Check if there is info already
        if (PlayerPrefs.HasKey("List") == false)
        {
            //Set up Arrays of floats
            for (int i = 0; i < 9; i++)
            {
                userscores[i] = float.Parse(GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).GetComponent<Text>().text);
            }

            //Set up Arrays of strings
            for (int i = 0; i < 9; i++)
            {
                usernames[i] = GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text;
            }
        }
    }

    void Update()
    {
        //Array counter to replace
        

        // int counter_array = 9;
        // if (menuManager.score_text < userscores[count])
        // {
        //     count += 1;
        // }
        // else if (menuManager.score_text > userscores[count])
        // {
        //     if ((counter_array - 1) != count)
        //     {
        //         userscores[counter_array] = userscores[counter_array - 1];
        //         counter_array -= 1;
        //     }
        // }

        //print
    }
    public void buttonChangeSceneO()
    {
        SceneManager.LoadScene("Welcome(now)");
    }
}

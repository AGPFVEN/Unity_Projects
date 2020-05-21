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
    int userscore;

    //Listas
    string[] usernames;
    int[] userscores;

    //Contador
    int count;

    //booleano controlador
    public bool firstdone;

    void Start()
    {
        firstdone = false;

        //Contador
        count = 1;

        //Menumanager
        menuManager = GameObject.Find("SceneManager").GetComponent<MenuManager>();

        //Arrays
        userscores = new int[9];
        usernames = new string[9];

        //Check if there is info already
        if (PlayerPrefs.HasKey($"userscores1") == false)
        {
            for (int i = 0; i < 9; i++)
            {
                //Set up Arrays of floats
                userscores[i] = int.Parse(GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).GetComponent<Text>().text);

                //Set up Arrays of strings
                usernames[i] = GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text;
            }
        }
        if (PlayerPrefs.HasKey($"userscores0") == true)
        {
            for (int i = 0; i < 9; i++)
            {
                //Set up Arrays of floats
                GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt($"userscores{i}").ToString();

                //Set up Arrays of strings
                GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetString($"usernames{i}");
            }
        }
        firstdone = true;
    }
    void FixedUpdate()
    {
        if (menuManager.count == 9)
        {
            // //Update array (int)
            for (int i = 0; i < 9; i++)
            {
                userscores[i] = int.Parse(GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).GetComponent<Text>().text);
                PlayerPrefs.SetInt($"userscores{i}", userscores[i]);
                usernames[i] = GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text;
                PlayerPrefs.SetString($"usernames{i}", usernames[i]);
            }
        }
    }
    public void buttonChangeSceneO()
    {
        SceneManager.LoadScene("Welcome(now)");
    }
}

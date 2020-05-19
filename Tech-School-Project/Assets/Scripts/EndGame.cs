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

    void Start()
    {
        //Contador
        count = 1;

        //Menumanager
        menuManager = GameObject.Find("SceneManager").GetComponent<MenuManager>();

        //Arrays
        userscores = new int[9];
        usernames = new string[9];

        //Check if there is info already
        if (PlayerPrefs.HasKey("List") == false)
        {
            //Set up Arrays of floats
            for (int i = 0; i < 9; i++)
            {
                userscores[i] = int.Parse(GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).GetComponent<Text>().text);
            }

            //Set up Arrays of strings
            for (int i = 0; i < 9; i++)
            {
                usernames[i] = GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text;
            }
        }
        if (PlayerPrefs.HasKey("List") == true)
        {
            //Set up Arrays of floats
            for (int i = 0; i < 9; i++)
            {
                GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt($"userscores{i}").ToString();
            }

            //Set up Arrays of strings
            for (int i = 0; i < 9; i++)
            {
                GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetString($"userscores{i}");
            }
        }
    }

    void FixedUpdate()
    {
        if (menuManager.count == 9)
        {
            //Update array (int)
            for (int i = 0; i < 9; i++)
            {
                userscores[i] = int.Parse(GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).GetComponent<Text>().text);
                PlayerPrefs.SetFloat($"userscores{i}", userscores[i]);
            }
            //Update array (strings)
            for (int i = 0; i < 9; i++)
            {
                usernames[i] = GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text;
                PlayerPrefs.SetString($"userscores{i}", usernames[i]);
            }
            Destroy(GameObject.Find("SceneManager"), 1);
        }
    }
    public void buttonChangeSceneO()
    {
        SceneManager.LoadScene("Welcome(now)");
    }
}

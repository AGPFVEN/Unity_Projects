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
    float[] userscores;
    string[] usernames;

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
    }

    void Update()
    {
        if (menuManager.score_text > userscores[count])
        {
            
        }
    }
    public void buttonChangeSceneO()
    {
        SceneManager.LoadScene("Welcome(now)");
    }
}

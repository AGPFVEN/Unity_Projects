using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //Score (this try)
    public int score_text;
    public string username;
    public int count;

    //Old score
    public int score_old;
    public string username_old;

    //TODO: LISTAS
    // string[] usernames;
    // string[] userscores;

    //Checkear listas
    bool checklistdone;

    //Checkear primer change
    bool changedone;

    //Final scene details
    EndGame endGamemanager;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        count = 1;

        //Go to other scene
        checklistdone = false;
        changedone = false;
    }
    void FixedUpdate()
    {
        //UserName
        if (SceneManager.GetActiveScene().name == "Welcome(now)")
        {
            username = GameObject.Find("Canvas").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text;
        }
        //Score
        if (SceneManager.GetActiveScene().name == "Juego_1")
        {
            score_text = GameObject.Find("Canvas").GetComponent<Interfaz>().score;
        }
        //Scoreboard
        if (SceneManager.GetActiveScene().name == "EndGame")
        {
            endGamemanager = GameObject.Find("Canvas").GetComponent<EndGame>();
            if (endGamemanager.firstdone == true)
            {
                if (checklistdone == false)
                {
                    endGamemanager = GameObject.Find("Canvas").GetComponent<EndGame>();

                    //Checklist done
                    checklistdone = true;
                }
                if (int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text) <= score_text && changedone == false && count < 9)
                {
                    //old score
                    score_old = int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text);

                    //Old Username
                    username_old = GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(1).GetComponent<Text>().text;

                    //Score
                    GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text = score_text.ToString();

                    //Username
                    GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(1).GetComponent<Text>().text = username;

                    //Change values
                    changedone = true;
                    count++;
                }
                if (changedone == true && count < 9)
                {
                    //Bucle de cambios
                    score_text = int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text);
                    username = GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(1).GetComponent<Text>().text;
                    GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text = score_old.ToString();
                    GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(1).GetComponent<Text>().text = username_old;
                    score_old = score_text;
                    username_old = username;
                    count += 1;
                }
                if (int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text) > score_text && changedone == false && count < 9)
                {
                    count += 1;
                }
                if (count == 9 && changedone)
                {
                    if (score_old > score_text)
                    {
                        GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text = score_text.ToString();
                    }
                    else
                    {
                        GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text = score_text.ToString();
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
    public void Username(string name)
    {
        username = name;
    }
    void CalculatePos(string scoreOfPos, int scoreMine)
    {
        int scoreOfPos_int = int.Parse(scoreOfPos);
    }
}
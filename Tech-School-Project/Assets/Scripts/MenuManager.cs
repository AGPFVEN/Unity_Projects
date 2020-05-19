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
            //TODO: SOLVE THISSSSSSS
            if (checklistdone == false)
            {
                // if (PlayerPrefs.HasKey("List") == false)
                // {
                //     //Set up Arrays of floats
                //     for (int i = 0; i < 9; i++)
                //     {
                //         userscores[i] = GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).gameObject.GetComponent<Text>().text;
                //     }

                //     //Set up Arrays of strings
                //     for (int i = 0; i < 9; i++)
                //     {
                //         usernames[i] = GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text;
                //     }
                // }

                endGamemanager = GameObject.Find("Canvas").GetComponent<EndGame>();

                //Checklist done
                checklistdone = true;
            }


            if (int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text) < score_text && changedone == false && count < 9)
            {
                //old score
                score_old = int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text);

                //Username
                GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(1).GetComponent<Text>().text = count + ". " + username;

                //Score
                GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text = score_text.ToString();

                //Change values
                changedone = true;
                count++;
            }
            if (changedone == true && count < 9)
            {
                score_text = int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text);
                GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text = score_old.ToString();
                score_old = score_text;
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
            }
        }
    }
    public void Username(string name)
    {
        username = name;
    }
    public void buttonChangeScene()
    {
        SceneManager.LoadScene("Juego_1");
    }
    public void buttonChangeSceneO()
    {
        SceneManager.LoadScene("Welcome(now)");
    }
    void CalculatePos(string scoreOfPos, int scoreMine)
    {
        int scoreOfPos_int = int.Parse(scoreOfPos);
    }
}
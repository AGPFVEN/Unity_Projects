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
    int count;

    //Old score
    public int score_old;

    //Listas
    string[] usernames;
    int[] userscores;

    //Checkear listas
    bool checklistdone;

    //Checkear primer change
    bool changedone;

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
            if (GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(2) != null)
            {
                username = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text;
            }
        }
        //Score
        if (SceneManager.GetActiveScene().name == "Juego_1")
        {
            score_text = GameObject.Find("Canvas").GetComponent<Interfaz>().score;
        }
        //Scoreboard
        if (SceneManager.GetActiveScene().name == "EndGame")
        {
            // if (checklistdone == false)
            // {
            //     if (PlayerPrefs.HasKey("List") == false)
            //     {
            //         //Set up Arrays of floats
            //         for (int i = 0; i < 9; i++)
            //         {
            //             userscores[i] = float.Parse(GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(0).gameObject.GetComponent<Text>().text);
            //         }

            //         //Set up Arrays of strings
            //         for (int i = 0; i < 9; i++)
            //         {
            //             usernames[i] = GameObject.Find("Canvas").transform.GetChild(i + 1).transform.GetChild(1).GetComponent<Text>().text;
            //         }
            //     }
            //     //Checklist done
            //     checklistdone = true;
            // }
            if (int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text) < score_text)
            {
                //old score
                score_old = int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text);

                //Username
                GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(1).GetComponent<Text>().text = count + ". " + username;

                //Score
                GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text = score_text.ToString();

                //Change values
                changedone = true;
                // score_text = float.Parse(GameObject.Find("Canvas").transform.GetChild(count + 1).transform.GetChild(0).GetComponent<Text>().text);
                // GameObject.Find("Canvas").transform.GetChild(count+1).transform.GetChild(0).GetComponent<Text>().text = score_old.ToString();
            }
            if (changedone == true)
            {
                score_text = int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text);
                GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text = score_old.ToString();
                score_old = score_text;
                if (count < 9)
                {
                    count += 1;
                }
            }
            if (int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text) > score_text && changedone == false)
            {
                if (count < 9)
                {
                    count += 1;
                }
            }
        }
        print(count);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //Score (this try)
    public float score_text;
    public string username;
    int count;

    //Old score
    // float score_old;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        count = 1;
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
            if (float.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text) < score_text)
            {
                //Username
                GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(1).GetComponent<Text>().text =
                count + ". " + username;

                //Score
                GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text =
                score_text.ToString();

                //Save changes
                PlayerPrefs.SetInt("Scoreboard", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();

                //Destroy GameObject
                Destroy(gameObject);
            }
            else if (int.Parse(GameObject.Find("Canvas").transform.GetChild(count).transform.GetChild(0).GetComponent<Text>().text) > score_text)
            {
                count += 1;
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
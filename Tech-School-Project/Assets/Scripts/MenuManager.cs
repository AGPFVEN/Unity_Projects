using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //Score
    Text score_text;
    public string username;
    public int score;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            return;
        }
        else if (GameObject.Find("Player") != null)
        {
            score_text = GameObject.Find("Canvas").transform.GetChild(2).gameObject.GetComponent<Text>();
            score_text.text = $"Score: {score}";
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
}

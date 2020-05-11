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
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
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

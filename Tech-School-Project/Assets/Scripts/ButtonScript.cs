using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    //Set up (button to scene 1)
    public GameObject playerPrefabs;
    string originalname;
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("SceneManager_tag") == true)
        {
            originalname = GameObject.FindGameObjectWithTag("SceneManager_tag").GetComponent<MenuManager>().username;
        }
    }
    public void buttonChangeSceneO()
    {
        SceneManager.LoadScene("Welcome(now)");
    }
    public void buttonChangeScene1()
    {
        Instantiate(playerPrefabs);
        GameObject.FindGameObjectWithTag("SceneManager_tag").GetComponent<MenuManager>().username = originalname;
        SceneManager.LoadScene("Juego_1");
    }
    public void buttonExitGame()
    {
        Application.Quit();
    }
}

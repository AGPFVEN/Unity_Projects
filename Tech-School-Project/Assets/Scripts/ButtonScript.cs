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
    void Awake()
    {
        originalname = GameObject.FindGameObjectWithTag("SceneManager_tag").GetComponent<MenuManager>().username;
    }
    void Update()
    {
        print(originalname);
    }
    public void buttonChangeSceneO()
    {
        SceneManager.LoadScene("Welcome(now)");
        Destroy(GameObject.FindGameObjectWithTag("SceneManager_tag"));
    }
    public void buttonChangeScene1()
    {
        if (SceneManager.GetActiveScene().name == "EndGame")
        {
            Instantiate(playerPrefabs);
            GameObject.FindGameObjectWithTag("SceneManager_tag").GetComponent<MenuManager>().username = originalname;
        }
        SceneManager.LoadScene("Juego_1");
    }
    public void buttonExitGame()
    {
        Application.Quit();
    }
}
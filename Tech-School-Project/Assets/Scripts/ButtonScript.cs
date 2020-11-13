using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ButtonScript : MonoBehaviour
{
    //Set up (button to scene 1)
    public GameObject playerPrefabs;
    string originalname;
    void Awake()
    {
        //Autofocus
        InputField username_field = GameObject.Find("InputField").GetComponent<InputField>();
        username_field.ActivateInputField();

        //Get username
        originalname = GameObject.FindGameObjectWithTag("SceneManager_tag").GetComponent<MenuManager>().username;
    }
    void Update()
    {
        print(originalname);

        //When eneter is pressed pass scene
        if(Input.GetKeyDown(KeyCode.Return))
        {
            buttonChangeScene1();
        }
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
    IEnumerator phpCheck()
    {
        string username = GameObject.Find("Canvas").transform.Find("InputField").transform.Find("Text").GetComponent<Text>().text;
        string password = GameObject.Find("Canvas").transform.Find("InputField(1)").transform.Find("Text").GetComponent<Text>().text;

        using(UnityWebRequest www = UnityWebRequest.Get("http://localhost/Backend-repository/AGPFVEN/Tech-School-Project_php/save_mark.php?username=" + username + "?password=" + password))
        {
            yield return www.Send();

            if(www.isNetworkError || www.isHttpError)
            {
                print(www.error);
            }
            else
            {
                print(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }
    public void PhpCheck()
    {
        StartCoroutine(phpCheck());
    }
}
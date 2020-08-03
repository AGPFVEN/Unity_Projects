using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class test1 : MonoBehaviour
{
    void Start()
    {

    }
    IEnumerator Uploadscore()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Backend-repository/AGPFVEN/Tech-School-Project_php/save_mark.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

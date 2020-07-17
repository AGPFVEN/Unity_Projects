using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ClearPlayerPrefs : EditorWindow
{
    [MenuItem("Tools/Reset Player Prefs")]
    public static void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("***Player Pref deleted***");
    }
}

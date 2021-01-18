using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataBase : MonoBehaviour
{


    public static List<string> StageContents()
    {
        List<string> contents;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Stage":
                contents = new List<string>() { "N", "N", "N", "N", "G" };
                break;
            default:
                contents = new List<string>() { "N", "N", "N", "N","N","L","N", "G" };
                break;
        }
        Debug.Log(contents);
        return contents;
    } 
    public static float StageLength()
    {
        float s;
        switch (SceneManager.GetActiveScene().name)
        {
            default:
                s = 50 * 8-25;
                break;
        }
        return s;
    }
}

enum Mode
{
    Easy=1,
    Normal=2,
    Difficult=3
}
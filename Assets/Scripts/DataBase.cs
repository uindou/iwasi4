using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataBase : MonoBehaviour
{


    public static Mode GameMode;

    public static List<string> StageContents()
    {
        List<string> contents;
        switch (SceneManager.GetActiveScene().name)
        {
            case "PreStage":
                switch (GameMode)
                {
                    case Mode.Easy:
                        contents = new List<string>() { "N", "N", "N", "N", "G" };
                        break;
                    case Mode.Normal:
                        contents = new List<string>() { "N", "N", "N", "N", "N", "L", "N", "G" };
                        break;
                    case Mode.Difficult:
                        contents = new List<string>() { "N", "N", "N", "N", "L","L","L","N","G" };
                        break;
                    default:
                        contents = new List<string>() { "N", "N", "N", "N", "G" };
                        break;
                }
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
        float s=0;
        List<string> stage = StageContents();
        s = 50*stage.Count()-25;
        
        return s;
    }
}

public enum Mode
{
    Easy = 1,
    Normal = 2,
    Difficult = 3
}
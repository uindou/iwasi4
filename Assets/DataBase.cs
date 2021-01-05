using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static List<string> StageContents()
    {
        List<string> contents;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Stage1":
                contents = new List<string>() { "N", "N", "N", "N", "G" };
                break;
            default:
                contents = new List<string>() { "N", "N", "N", "N","N","N", "G" };
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
                s = 50 * 7-25;
                break;
        }
        return s;
    }
}

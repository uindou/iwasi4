using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IwasiGameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject);
        //safeっていうタグ以外のコライダーに衝突すると、ゲームオーバー処理が発生。とりあえずシーン遷移にしておく
        if (coll.gameObject.tag != "safe")
        {
            GameOver();
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("Title");
    }
}

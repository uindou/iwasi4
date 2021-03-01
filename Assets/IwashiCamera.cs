using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwashiCamera : MonoBehaviour
{

    public GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
    public GameObject stageManager;
    StageManager sm;

    // Use this for initialization
    void Start()
    {
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;
        sm = stageManager.GetComponent<StageManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!sm.Clear())
        {
            //新しいトランスフォームの値を代入する
            transform.position = player.transform.position + offset;
        }

       

    }
}
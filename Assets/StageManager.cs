using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private int stageNum;
    public GameObject Stage;
    public GameObject subStage;
    public Transform Player;
    public float deletePoint;

    private Queue<(GameObject, GameObject, GameObject)> q;
    private Transform OldStage;
    private int currentZ;

    void Awake()
    {
        q = new Queue<(GameObject,GameObject,GameObject)>();
        stageNum = 5;
        currentZ = - 1;
        for (int i = 0; i < stageNum; i++)
        {
            currentZ += 1;
            Vector3 zahyo = new Vector3(0, 0, i * 50);
            Vector3 zahyoR = new Vector3(50, 0, i * 50);
            Vector3 zahyoL = new Vector3(-50, 0, i * 50);
            GameObject obj = Instantiate(Stage, zahyo, Quaternion.identity);
            GameObject objR = Instantiate(subStage, zahyoR, Quaternion.identity);
            GameObject objL = Instantiate(subStage, zahyoL, Quaternion.identity);
            var objs = (obj, objR, objL);
            q.Enqueue(objs);
            StageInit(objs);
        }

        var (obj2, obj2R, obj2L) = q.Peek();
        OldStage = obj2.transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckBehind();
    }
    void CheckBehind()//一番後ろのステージのz座標を見て、十分後ろなら削除。そして、一番前に新しく生成
    {
        if (OldStage.position.z - Player.position.z < deletePoint)
        {
            StageDelete(q.Dequeue());
            StagePush();
        }
        var (obj, objR, objL) = q.Peek();
        OldStage = obj.transform;
    }
    void StagePush()
    { 
        Vector3 zahyo = new Vector3(0, 0, currentZ * 50);
        Vector3 zahyoR = new Vector3(50, 0, currentZ * 50);
        Vector3 zahyoL = new Vector3(-50, 0, currentZ * 50);
        GameObject obj = Instantiate(Stage, zahyo, Quaternion.identity);
        GameObject objR = Instantiate(subStage, zahyoR, Quaternion.identity);
        GameObject objL = Instantiate(subStage, zahyoL, Quaternion.identity);
        var objs = (obj, objR, objL);
        q.Enqueue(objs);
        StageInit(objs);
        currentZ += 1;
    }
    void StageInit((GameObject, GameObject, GameObject) objs)//ステージの付属パーツ(石や木)を作成して、ステージの子供にする。(ステージ自体の作成はStagePushで)
    {
        var (obj, objR, objL) = objs;
        GameObject target = obj.transform.GetChild(0).gameObject;
        //石を追加する処理
        partsPutter rock;
        rock = target.GetComponent<partsPutter>();
        rock.Init(obj.transform,true);
        //右のやつに草木を追加
        partsPutter rock2;
        rock2 = objR.GetComponent<partsPutter>();
        rock2.Init(objR.transform,false);
        //左のやつに草木を追加
        partsPutter rock3;
        rock3 = objL.GetComponent<partsPutter>();
        rock3.Init(objL.transform,false);
    }

    void StageDelete((GameObject, GameObject, GameObject) objs)//ステージとその子供を削除する。
    {
        var (obj, objR, objL) = objs;
        foreach (Transform child in obj.transform)
        {
            // 一つずつ破棄する
            Destroy(child.gameObject);
        }
        Destroy(obj);
        Destroy(objR);
        Destroy(objL);
    }
}

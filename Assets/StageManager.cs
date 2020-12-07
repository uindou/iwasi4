using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private int stageNum;
    public GameObject Stage;
    public Transform Player;
    public float deletePoint;

    private Queue<GameObject> q;
    private Transform OldStage;
    private int currentZ;

    void Awake()
    {
        q = new Queue<GameObject>();
        stageNum = 5;
        currentZ = - 1;
        for (int i = 0; i < stageNum; i++)
        {
            currentZ += 1;
            Vector3 zahyo = new Vector3(0, 0, i * 50);
            GameObject obj = Instantiate(Stage, zahyo, Quaternion.identity);
            q.Enqueue(obj);
            StageInit(obj);
        }
        OldStage = q.Peek().transform;
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
        OldStage = q.Peek().transform;
    }
    void StagePush()
    {
        Vector3 zahyo = new Vector3(0, 0, currentZ * 50);
        GameObject obj = Instantiate(Stage, zahyo, Quaternion.identity);
        q.Enqueue(obj);
        StageInit(obj);
        currentZ += 1;
    }
    void StageInit(GameObject obj)//ステージの付属パーツ(石や木)を作成して、ステージの子供にする。(ステージ自体の作成はStagePushで)
    {
        GameObject target = obj.transform.GetChild(0).gameObject;
        //石を追加する処理
        partsPutter rock;
        rock = target.GetComponent<partsPutter>();
        rock.Init((float)currentZ*50,obj.transform);
    }

    void StageDelete(GameObject obj)//ステージとその子供を削除する。
    {
        foreach (Transform child in obj.transform)
        {
            // 一つずつ破棄する
            Destroy(child.gameObject);
        }
        Destroy(obj);
    }
}

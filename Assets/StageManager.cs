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
        stageNum = 3;
        currentZ = stageNum - 1;
        for (int i = 0; i < stageNum; i++)
        {
            Vector3 zahyo = new Vector3(0, 0, i * 50);
            q.Enqueue(Instantiate(Stage, zahyo, Quaternion.identity));
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
            Destroy(q.Dequeue());
            StagePush();
        }
        OldStage = q.Peek().transform;
    }
    void StagePush()
    {
        Vector3 zahyo = new Vector3(0, 0, currentZ * 50);
        q.Enqueue(Instantiate(Stage, zahyo, Quaternion.identity));
        currentZ += 1;
    }
}

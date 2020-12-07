using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

public class rockTester : MonoBehaviour
{
    public GameObject rock;
    public int rock_num;
    public bool checkok;
    public List<(float, float)> zahyos;
    public List<(float, float)> glasses;
    private List<GameObject> rocks;
    // Start is called before the first frame update
    void Start()
    {
        zahyos = new List<(float, float)>();
        glasses = new List<(float, float)>();
        checkok = false;
        rocks = new List<GameObject>();
        for(int i = 0; i < rock_num; i++)
        {
            Vector3 zahyo = new Vector3(Random.Range(0,50), 5,Random.Range(0,50));
            rocks.Add(Instantiate(rock, zahyo, Quaternion.identity));
        }
        WaitOneSecondAsync();
        

    }

    // Update is called once per frame
    void Update()
    {
        Transform tr;
        if (checkok)
        {
            for (int i = 0; i < rock_num; i++)
            {
                tr = rocks[i].transform;
                if (tr.position.y < 0)
                {
                    zahyos.Add((tr.position.x, tr.position.z));
                    //Debug.Log((tr.position.x, tr.position.z));
                }
                else
                {
                    glasses.Add((tr.position.x, tr.position.z));
                }
            }
            ShowListContentsInTheDebugLog(zahyos);
            ShowListContentsInTheDebugLog(glasses);
            checkok = false;
        }
    }

    private async Task WaitOneSecondAsync()
    {
        await Task.Delay(3000);
        checkok = true;
        Debug.Log("Finished waiting.");
    }
    public void ShowListContentsInTheDebugLog<T>(List<T> list)
    {
        string log = "";

        foreach (var content in list.Select((val, idx) => new { val, idx }))
        {
            if (content.idx == list.Count - 1)
                log += content.val.ToString();
            else
                log += content.val.ToString() + ", ";
        }

        Debug.Log(log);
    }
}

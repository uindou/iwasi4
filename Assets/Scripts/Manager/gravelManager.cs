using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Linq;
using System.Collections.Specialized;

public class gravelManager : MonoBehaviour
{
    public Transform gravelParent;
    public int GravelNum;
    private GameObject[] child = new GameObject[6];
    void Awake()
    {
        int i = 0;
        foreach (Transform chi in gravelParent)
        {
            child[i] = chi.gameObject;
            i += 1;
        }
        float center = 25f;
        for (i = 0; i < 100; i++)//縦の長さは50mある。100分割して、0.5mおきに砂利を降らせる
        {
            for (int j = 0; j < GravelNum; j++)
            {
                GameObject obj = child[Random.Range(0, 6)];
                Vector3 zahyo = new Vector3(center + Random.value * 3 - 1.5f, 0f, ((float)i) / 2 + 25f);
                Instantiate(obj, zahyo, Quaternion.identity);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

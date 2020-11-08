using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class meshChanger : MonoBehaviour
{
    public float radius;
    public float swell;
    public float sharow;
    // Start is called before the first frame update
    void Awake()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        Vector3[] vertices = meshFilter.mesh.vertices;//メッシュを構成する点集合の座標
        float center;
        var (minV,maxV) = returnMinMax(vertices);
        center = (maxV.x+minV.x)/2;
        center = 25;

        for (int i = 0; i < vertices.Length; i++)
        {
            if(Mathf.Abs(vertices[i].x + swell*Mathf.Sin(vertices[i].z*Mathf.PI/25) - center)<=radius){
                float cos = Mathf.Abs(vertices[i].x + swell*Mathf.Sin(vertices[i].z*Mathf.PI/ 25) - center)/radius;
                float sin = Mathf.Sqrt(1-Mathf.Pow(cos,2));
                //知りたいのはsinθ
                vertices[i].y -= sin*radius*sharow;
            }
        }
        for(int i=0;i<vertices.Length;i++){
            vertices[i].y += GetNorm(0.05f);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateNormals();

        MeshCollider meshcollider = this.gameObject.GetComponent<MeshCollider>();
        if(!meshcollider) meshcollider = this.gameObject.AddComponent<MeshCollider>();
    }

    (Vector3,Vector3) returnMinMax(Vector3[] vec)
    //meshを構成する点(vertice)のうち、最大の(x,y,z)と最小の(x,y,z)を返す
    {
        float mx, my, mz, Mx, My, Mz;
        float inf = 1000;
        mx = inf;
        my = inf;
        mz = inf;
        Mx = -inf;
        My = -inf;
        Mz = -inf;
        foreach(Vector3 ve in vec)
        {
            mx = Mathf.Min(mx, ve.x);
            my = Mathf.Min(my, ve.y);
            mx = Mathf.Min(mz, ve.z);
            Mx = Mathf.Max(Mx, ve.x);
            My = Mathf.Max(My, ve.y);
            Mz = Mathf.Max(Mz, ve.z);
        }
        Vector3 minV = new Vector3(mx,my,mz);
        Vector3 maxV = new Vector3(Mx,My,Mz);
        return (minV,maxV);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public float GetNorm(float sigma)
    {
        float s = 0;
        int k = 50;
        for(int i = 0; i < k; i++)
        {
            s += Random.value * sigma;
        }
        s -= k * sigma / 2;
        return s;
    }

}
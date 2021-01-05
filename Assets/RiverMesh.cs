using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class RiverMesh : MonoBehaviour
{
    private float radius;
    private float swell;
    private float sharow;
    // Start is called before the first frame update
    void Awake()
    {
        radius = 5f;
        swell = 3f;
        sharow = 0.7f;
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        Vector3[] vertices = meshFilter.mesh.vertices;//メッシュを構成する点集合の座標
        float center;
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
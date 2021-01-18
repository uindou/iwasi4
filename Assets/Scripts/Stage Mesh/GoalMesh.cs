using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMesh : MonoBehaviour
{
    private float radiusX;
    private float radiusY;
    private float radius2;
    private float swell;
    private float sharow;
    void Awake()
    {
        radiusX = 20f;
        radiusY = 50f;
        swell = 3f;
        sharow = 3f;
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        Vector3[] vertices = meshFilter.mesh.vertices;//メッシュを構成する点集合の座標
        float center;
        center = 25;

        for (int i = 0; i < vertices.Length; i++)
        {
            if (vertices[i].x <= 25)//左のだ円。中心は(0,0)
            {
                if(Mathf.Pow((vertices[i].x/radiusX),2)+ Mathf.Pow((vertices[i].z / radiusY), 2)>=1)
                {
                    vertices[i].y -= sharow;
                }

            }
            else if (vertices[i].x > 25)//右のだ円。中心は(50,0)
            {
                if (Mathf.Pow((vertices[i].x-50), 2)/(radiusX*radiusX) + Mathf.Pow((vertices[i].z / radiusY), 2) >= 1)
                {
                    vertices[i].y -=  sharow;
                }
            }

        }
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y += GetNorm(0.05f);
        }

        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateNormals();

        MeshCollider meshcollider = this.gameObject.GetComponent<MeshCollider>();
        if (!meshcollider) meshcollider = this.gameObject.AddComponent<MeshCollider>();
    }
    public float GetNorm(float sigma)
    {
        float s = 0;
        int k = 50;
        for (int i = 0; i < k; i++)
        {
            s += Random.value * sigma;
        }
        s -= k * sigma / 2;
        return s;
    }
}
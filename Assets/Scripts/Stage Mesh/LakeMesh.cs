using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeMesh : MonoBehaviour
{
    // Start is called before the first frame update    
    void Awake()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        Vector3[] vertices = meshFilter.mesh.vertices;//メッシュを構成する点集合の座標
        float depth = 3;
        for (int i = 0; i < vertices.Length; i++)
        {
            switch (devide(vertices[i].x))
            {
                case 1:
                    if(Mathf.Pow((vertices[i].x-25),2)+ Mathf.Pow((vertices[i].z - 25), 2) < 400*(0.9+0.2*Random.value))
                    {
                        vertices[i].y -= depth;
                    }
                    break;
                case 2:
                    if(5<vertices[i].z || vertices[i].z < 45)
                    {
                        vertices[i].y -= depth;
                    }
                    else
                    {
                        float cos = Mathf.Abs(vertices[i].x - 25) / 5;
                        float sin = Mathf.Sqrt(1 - cos * cos);
                        vertices[i].y -= sin*depth;
                    }
                    break;
                case 3:
                    if (Mathf.Pow((vertices[i].x - 25), 2) + Mathf.Pow((vertices[i].z - 25), 2) < 400 * (0.9 + 0.2 * Random.value))
                    {
                        vertices[i].y -= depth;
                    }
                    break;
                default:
                    break;
            }
        }
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateNormals();
    }
    private int devide(float x)
    {
        if (x < 20)
        {
            return 1;
        }
        else if (x < 30)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }

}

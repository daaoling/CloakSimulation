using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class createMesh
{
    static int[] GenerateCachedIndexBuffer(int vertexCount, int triangleCount)
    {
        int[] rv = new int[triangleCount];
        int index = 0;

        for (int i = 0; i < vertexCount; i += 4)
        {
            rv[index++] = i;
            rv[index++] = i + 1;
            rv[index++] = i + 2;

            rv[index++] = i + 2;
            rv[index++] = i + 3;
            rv[index++] = i;
        }
        return rv;
    }

    [MenuItem("Test/CreateMesh")]
    public static void CreateCloak()
    {
        Mesh mMesh = new Mesh();


        var cellNum = 2;
        //mMesh.vertices = new Vector3[4 * cellNum];
        //mMesh.uv = new Vector2[4 * cellNum];
        //mMesh.colors32 = new Color32[4 * cellNum];
        //for (int i = 0; i < cellNum; i++)
        //{
        //    mMesh.vertices[i * 4 + 0] = new Vector3(-1, 0 + (-1 * i), 0);
        //    mMesh.vertices[i * 4 + 1] = new Vector3(1, 0 + (-1 * i), 0);
        //    mMesh.vertices[i * 4 + 2] = new Vector3(1, -1 + (-1 * i), 0);
        //    mMesh.vertices[i * 4 + 3] = new Vector3(-1, -1 + (-1 * i), 0);

        //    mMesh.uv[i * 4 + 0] = new Vector2(0, 0);
        //    mMesh.uv[i * 4 + 1] = new Vector2(0, 1);
        //    mMesh.uv[i * 4 + 2] = new Vector2(1, 1);
        //    mMesh.uv[i * 4 + 3] = new Vector2(1, 0);

        //    mMesh.colors32[i * 4 + 0] = Color.white;
        //    mMesh.colors32[i * 4 + 1] = Color.white;
        //    mMesh.colors32[i * 4 + 2] = Color.white;
        //    mMesh.colors32[i * 4 + 3] = Color.white;
        //}


        mMesh.vertices = new Vector3[] { 
            new Vector3(-1,0,0), 
            new Vector3(1,0,0),
            new Vector3(1,-1,0),
            new Vector3(-1,-1,0),

            new Vector3(-1,-1,0),
            new Vector3(1,-1,0),
            new Vector3(1,-2,0),
            new Vector3(-1,-2,0),

            new Vector3(-1,-2,0),
            new Vector3(1,-2,0),
            new Vector3(1,-3,0),
            new Vector3(-1,-3,0)
        };
        mMesh.uv = new Vector2[] { 
            new Vector2(0,0), 
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,0), 
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),

            new Vector2(0,0), 
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)
        };
        mMesh.colors32 = new Color32[] { 
            Color.white,
            Color.white,
            Color.white,
            Color.white,

            Color.white,
            Color.white,
            Color.white,
            Color.white,

            Color.white,
            Color.white,
            Color.white,
            Color.white
        };
        int count = mMesh.vertices.Length;
        int indexCount = (count >> 1) * 3;
        var mIndices = GenerateCachedIndexBuffer(count, indexCount);
        mMesh.triangles = mIndices;

        var path = "Assets/mMesh.asset";
        AssetDatabase.CreateAsset(mMesh, path);
        AssetDatabase.SaveAssets();
    }
}

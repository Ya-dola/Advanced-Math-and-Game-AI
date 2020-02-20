using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int Width;
    public int Depth;
    [Header("Vertex visualization")]
    public GameObject VertexObject;
    public bool VisualizeVertices;

    private Vector3[] vertices;
    private int[] trianglePoints;
    private Mesh mesh;
    private MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh.name = "Procedural Terrain";
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        CreateMesh();
        UpdateMesh();
        if (VisualizeVertices)
        {
            DrawVertices();
        }
    }

    private void DrawVertices()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Instantiate(VertexObject, vertices[i], Quaternion.identity, transform);
        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = trianglePoints;
        mesh.RecalculateNormals();
    }

    void CreateMesh()
    {

        vertices = new Vector3[(Width + 1) * (Depth + 1)];

        int i = 0;
        for (int z = 0; z <= Depth; z++)
        {
            for (int x = 0; x <= Width; x++)
            {
                vertices[i] = new Vector3(x, 0, z);
                i++;
            }
        }

        trianglePoints = new int[Width * Depth * 6];
        int currentTrianglePoint = 0;
        int currentVertexPoint = 0;

        for (int z = 0; z < Depth; z++)
        {
            for (int x = 0; x < Width; x++)
            {
                trianglePoints[currentTrianglePoint + 0] = currentVertexPoint + 0;
                trianglePoints[currentTrianglePoint + 1] = currentVertexPoint + Width + 1;
                trianglePoints[currentTrianglePoint + 2] = currentVertexPoint + 1;
                trianglePoints[currentTrianglePoint + 3] = currentVertexPoint + 1;
                trianglePoints[currentTrianglePoint + 4] = currentVertexPoint + Width + 1;
                trianglePoints[currentTrianglePoint + 5] = currentVertexPoint + Width + 2;

                currentVertexPoint++;
                currentTrianglePoint += 6;
            }
            currentVertexPoint++;
        }
    }
}

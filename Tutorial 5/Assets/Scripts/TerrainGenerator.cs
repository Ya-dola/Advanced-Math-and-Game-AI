﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Terrain generation")]
    public int Width;
    public int Depth;
    public Gradient gradient;
    public int Seed;
    [Range(1,100)]
    public int Octaves;
    [Range(1, 100)]
    public float NoiseScale;
    [Range(0, 1)]
    public float Persistance;
    [Range(1, 100)]
    public float Lacunarity;
    [Range(1, 100)]
    public float HeightMultiplier;
    [Range(0, 1)]
    public float HeightTreshhold;
    public Vector2 Offset;

    [Header("Vertex visualization")]
    public GameObject VertexObject;
    public bool VisualizeVertices;

    private Vector3[] vertices;
    private int[] trianglePoints;
    Vector2[] uvs;
    Color[] colors;
    private Mesh mesh;
    private MeshFilter meshFilter;
    private float minHeight;
    private float maxHeight;
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
        mesh.uv = uvs;
        mesh.colors = colors;
        mesh.RecalculateNormals();
    }

    void CreateMesh()
    {
        //Vertices
        vertices = new Vector3[(Width + 1) * (Depth + 1)];
        var noiseArray = PerlinNoise();

        int i = 0;
        for (int z = 0; z <= Depth; z++)
        {
            for (int x = 0; x <= Width; x++)
            {
                var currentHeight = noiseArray[i];
                if (currentHeight > HeightTreshhold)
                {
                    currentHeight *= HeightMultiplier;
                }
                vertices[i] = new Vector3(x, currentHeight, z);
                i++;
            }
        }

        //Triangles
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

        //UVs
        uvs = new Vector2[vertices.Length];
        i = 0;
        for (int z = 0; z <= Depth; z++)
        {
            for (int x = 0; x <= Width; x++)
            {
                uvs[i] = new Vector2((float)x / Width, (float)z / Depth);
                i++;
            }
        }

        //Colors
        colors = new Color[vertices.Length];
        i = 0;
        for (int z = 0; z <= Depth; z++)
        {
            for (int x = 0; x <= Width; x++)
            {
                float height = Mathf.InverseLerp(minHeight * HeightMultiplier, maxHeight * HeightMultiplier, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
            }
        }
    }

    float[] PerlinNoise()
    {
        float[] noiseArray = new float[(Width + 1) *  (Depth + 1)];

        System.Random prng = new System.Random(Seed);
        Vector2[] octaveOffsets = new Vector2[Octaves];
        for (int i = 0; i < Octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + Offset.x;
            float offsetY = prng.Next(-100000, 100000) + Offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        float halfWidth = Width / 2f;
        float halfDepth = Depth / 2f;

        //Apply lacunarity and persistence
        int n = 0;
        for (int z = 0; z <= Depth; z++)
        {
            for (int x = 0; x <= Width; x++)
            {

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                //Use multiple frequencies (octaves)
                for (int i = 0; i < Octaves; i++)
                {
                    float sampleX = (x - halfWidth) / NoiseScale * frequency + octaveOffsets[i].x;
                    float sampleY = (z - halfDepth) / NoiseScale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= Persistance;
                    frequency *= Lacunarity;
                }

                if (noiseHeight > maxHeight)
                {
                    maxHeight = noiseHeight;
                }
                else if (noiseHeight < minHeight)
                {
                    minHeight = noiseHeight;
                }
                noiseArray[n] = noiseHeight;
                n++;
            }
        }

        //Normalize height
        int k = 0;
        for (int z = 0; z < Depth; z++)
        {
            for (int x = 0; x < Width; x++)
            {
                noiseArray[k] = Mathf.InverseLerp(minHeight, maxHeight, noiseArray[k]);
                k++;
            }
        }

        return noiseArray;
    }
}

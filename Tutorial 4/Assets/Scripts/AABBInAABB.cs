using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBInAABB : MonoBehaviour
{
    public Transform TestPoint;
    public Material CollisionMaterial;
    private Material defaultMaterial;
    private Renderer testPointRenderer;
    private BoxCollider aabbBoxCollider;
    private BoxCollider testPointBoxCollider;

    private void Start()
    {
        testPointRenderer = TestPoint.GetComponent<Renderer>();
        testPointBoxCollider = TestPoint.GetComponent<BoxCollider>();
        aabbBoxCollider = GetComponent<BoxCollider>();
        defaultMaterial = testPointRenderer.material;
    }

    private void Update()
    {
        var xAxisCheckMin = testPointBoxCollider.bounds.max.x > aabbBoxCollider.bounds.min.x;
        var xAxisCheckMax = testPointBoxCollider.bounds.min.x < aabbBoxCollider.bounds.max.x;

        var yAxisCheckMin = testPointBoxCollider.bounds.max.y > aabbBoxCollider.bounds.min.y;
        var yAxisCheckMax = testPointBoxCollider.bounds.min.y < aabbBoxCollider.bounds.max.y;

        var zAxisCheckMin = testPointBoxCollider.bounds.max.z > aabbBoxCollider.bounds.min.z;
        var zAxisCheckMax = testPointBoxCollider.bounds.min.z < aabbBoxCollider.bounds.max.z;

        if (xAxisCheckMin && xAxisCheckMax 
            && yAxisCheckMin && yAxisCheckMax
            && zAxisCheckMin && zAxisCheckMax)
        {
            Debug.Log("Collision!");
            testPointRenderer.material = CollisionMaterial;
        }
        else
        {
            testPointRenderer.material = defaultMaterial;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInAABB : MonoBehaviour
{
    public Transform TestPoint;
    public Material CollisionMaterial;
    private Material defaultMaterial;
    private Renderer testPointRenderer;
    private BoxCollider aabbBoxCollider;

    private void Start()
    {
        testPointRenderer = TestPoint.GetComponent<Renderer>();
        aabbBoxCollider = GetComponent<BoxCollider>();
        defaultMaterial = testPointRenderer.material;
    }

    private void Update()
    {
        var xAxisCheckMin = TestPoint.position.x > aabbBoxCollider.bounds.min.x;
        var xAxisCheckMax = TestPoint.position.x < aabbBoxCollider.bounds.max.x;

        var yAxisCheckMin = TestPoint.position.y > aabbBoxCollider.bounds.min.y;
        var yAxisCheckMax = TestPoint.position.y < aabbBoxCollider.bounds.max.y;

        var zAxisCheckMin = TestPoint.position.z > aabbBoxCollider.bounds.min.z;
        var zAxisCheckMax = TestPoint.position.z < aabbBoxCollider.bounds.max.z;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereToPlane : MonoBehaviour
{
    public Transform TestPoint;
    public Material CollisionMaterial;
    private Material defaultMaterial;
    private Renderer testPointRenderer;
    private SphereCollider testPointCollider;

    private void Start()
    {
        testPointCollider = TestPoint.GetComponent<SphereCollider>();
        testPointRenderer = TestPoint.GetComponent<Renderer>();
        defaultMaterial = testPointRenderer.material;
    }

    private Vector3 Normal
    {
        get
        {
            return transform.up;
        }
    }

    public Vector3 PointOnPlane { 
        get 
        {
            return transform.position;
        }
    }

    void Update()
    {
        Vector3 positionDifference = TestPoint.position - PointOnPlane;
        float result = Vector3.Dot(positionDifference, Normal);

        if(result > testPointCollider.radius)
        {
            testPointRenderer.material = defaultMaterial;
            Debug.Log("In Front");
        }
        else
        {
            testPointRenderer.material = CollisionMaterial;
            Debug.Log("On the plane or behind");
        }
    }
}

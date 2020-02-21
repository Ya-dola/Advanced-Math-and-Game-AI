using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfSpaceTest : MonoBehaviour
{
    public Transform TestPoint;
    public Material CollisionMaterial;
    private Material defaultMaterial;
    private Renderer testPointRenderer;

    private void Start()
    {
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

        if(result > 0)
        {
            testPointRenderer.material = defaultMaterial;
            Debug.Log("In Front");
        }
        else if (result < 0)
        {
            testPointRenderer.material = defaultMaterial;
            Debug.Log("Behind");
        }
        else
        {
            testPointRenderer.material = CollisionMaterial;
            Debug.Log("On the Plane");
        }
    }
}

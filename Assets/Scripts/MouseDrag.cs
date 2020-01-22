using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    bool isMouseDown;
    SpringJoint2D springJoint;
    TrailRenderer trailRenderer;

    private void Awake()
    {
        springJoint = GetComponent<SpringJoint2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    void OnMouseDown()
    {
        isMouseDown = true;
        springJoint.enabled = false;
        trailRenderer.enabled = false;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        springJoint.enabled = true;
        trailRenderer.enabled = true;
    }

    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, 0);
        }


    }
}

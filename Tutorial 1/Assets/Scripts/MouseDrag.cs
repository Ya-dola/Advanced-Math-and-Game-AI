using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public float MaxDistance = 3f;
    [HideInInspector]
    public bool isMouseDown;
    SpringJoint2D springJoint;
    TrailRenderer trailRenderer;
    Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
        springJoint = GetComponent<SpringJoint2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    void OnMouseDown()
    {
        initialPosition = transform.position;
        isMouseDown = true;
        springJoint.enabled = false;
        trailRenderer.enabled = false;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        springJoint.enabled = true;
        trailRenderer.enabled = true;
        StartCoroutine(LaunchProjectile());
    }

    IEnumerator LaunchProjectile()
    {
        yield return new WaitForSeconds(0.1f);
        springJoint.enabled = false;
    }

    void Update()
    {
        if (isMouseDown)
        {
            Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var newPosition = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, 0);

            var distance = Vector2.Distance(newPosition, initialPosition);

            if(distance > MaxDistance)
            {
                var direction = (newPosition - initialPosition).normalized;
                transform.position = initialPosition + direction * MaxDistance;
            }
            else
            {
                transform.position = newPosition;
            }
        }


    }
}

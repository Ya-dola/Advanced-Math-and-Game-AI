using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    MouseDrag mouseDrag;
    SpringJoint2D spring;
    Vector2 initialPosition;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        mouseDrag = GetComponent<MouseDrag>();
        spring = GetComponent<SpringJoint2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if(!spring.enabled && !mouseDrag.isMouseDown && rigidbody2d.velocity.magnitude < LevelManager.Instance.ResetSpeed)
        {
            ResetWeapon();
        }
    }

    public void ResetWeapon()
    {
        transform.position = initialPosition;
        spring.enabled = true;
    }
}

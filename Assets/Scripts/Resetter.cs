using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float resetSpeed = 1f;
    private SpringJoint2D spring;
    MouseDrag mouseDrag;

    void Start()
    {
        mouseDrag = projectile.GetComponent<MouseDrag>();
        spring = projectile.GetComponent<SpringJoint2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        //Debug.Log("Velocity: " + projectile.velocity.magnitude);
        if (!spring.enabled && !mouseDrag.isMouseDown && projectile.velocity.magnitude < resetSpeed)
        {
            Reset();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == projectile)
        {
            Reset();
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
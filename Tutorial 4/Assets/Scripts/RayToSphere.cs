using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToSphere : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forwardDirection * 100, Color.red);

        if (Physics.Raycast(transform.position, forwardDirection, out hit))
        {
            print("Found an object - distance: " + hit.distance);
            Debug.DrawRay(transform.position, forwardDirection * hit.distance, Color.black);
        }
        else
        {
            Debug.Log("Not intersecting!");
        }
    }
}

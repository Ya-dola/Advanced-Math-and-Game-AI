using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToSphere : MonoBehaviour
{
    public GameObject Point1;
    public GameObject Point2;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forwardDirection, Color.red);
        //RaycastHit[] hits;
        //hits = Physics.RaycastAll(transform.position, forwardDirection);

        if (Physics.Raycast(transform.position, forwardDirection, out hit))
        {
            print("Found an object - distance: " + hit.distance);
            Debug.DrawRay(transform.position, forwardDirection * hit.distance, Color.black);

            //RaycastHit hit2;
            //Physics.Raycast(hit.point, forwardDirection, out hit2);
            //Debug.DrawRay(hit.point, forwardDirection, Color.white);
        }
        else
        {
            Debug.Log("Not intersecting!");
        }
    }
}

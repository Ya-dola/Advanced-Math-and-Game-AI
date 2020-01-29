using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInput : MonoBehaviour
{
    private IRotation rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = GetComponent<IRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) {
            SetRotation(new Vector3(0, 0, -90));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            SetRotation(new Vector3(0, 0, 90));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            SetRotation(new Vector3(90, 0, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SetRotation(new Vector3(-90, 0, 0));
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            SetRotation(new Vector3(0, -90, 0));
        }
        else if (Input.GetKey(KeyCode.E))
        {
            SetRotation(new Vector3(0, 90, 0));
        }
    }

    void SetRotation(Vector3 rotationAngle)
    {
        rotation.AnglesToRotate = rotationAngle;
    }
}

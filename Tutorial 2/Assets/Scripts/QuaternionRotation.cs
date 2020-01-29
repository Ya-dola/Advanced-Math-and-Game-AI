using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionRotation : MonoBehaviour
{
    public Vector3 CurrentRotation;
    public Vector3 AnglesToRotate;

    void Start()
    {
        Quaternion yRotation = Quaternion.AngleAxis(CurrentRotation.y, Vector3.up);
        Quaternion xRotation = Quaternion.AngleAxis(CurrentRotation.x, Vector3.right);
        Quaternion zRotation = Quaternion.AngleAxis(CurrentRotation.z, Vector3.forward);
        transform.rotation = yRotation * xRotation * zRotation;
    }

    void Update()
    {
        Quaternion yRotation = Quaternion.AngleAxis(AnglesToRotate.y * Time.deltaTime, Vector3.up);
        Quaternion xRotation = Quaternion.AngleAxis(AnglesToRotate.x * Time.deltaTime, Vector3.right);
        Quaternion zRotation = Quaternion.AngleAxis(AnglesToRotate.z * Time.deltaTime, Vector3.forward);
        transform.rotation = yRotation * xRotation * zRotation * transform.rotation;

        CurrentRotation += AnglesToRotate * Time.deltaTime;

    }

}

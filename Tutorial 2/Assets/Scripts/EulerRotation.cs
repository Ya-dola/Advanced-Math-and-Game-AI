using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerRotation : MonoBehaviour
{
    //To create the Gimbal lock effect set:
    //1) CurrentRotation X to 90 
    //2) Angles to Rotate Z to 90 
    //CurrentRotation = new Vector3 (90f, 0f, 0f);
    //AnglesToRotate = new Vector3 (0f, 0f, 90f);

    public Vector3 CurrentRotation;
    public Vector3 AnglesToRotate;

    void Start()
    {
        transform.eulerAngles = CurrentRotation;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentRotation += AnglesToRotate * Time.deltaTime;
        transform.eulerAngles = CurrentRotation;
    }
}

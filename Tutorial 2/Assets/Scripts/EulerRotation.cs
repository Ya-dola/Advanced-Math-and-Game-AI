using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerRotation : MonoBehaviour, IRotation
{
    //One way to create the Gimbal lock effect:
    //1) Set CurrentRotation X to 90 
    //2) Set AnglesToRotate Z to 90 
    //CurrentRotation = new Vector3 (90f, 0f, 0f);
    //AnglesToRotate = new Vector3 (0f, 0f, 90f);

    [SerializeField]
    private Vector3 _currentRotation;
    [SerializeField]
    private Vector3 _anglesToRotate;

    public Vector3 CurrentRotation
    {
        get
        {
            return _currentRotation;
        }
        set
        {
            _currentRotation = value;
        }
    }

    public Vector3 AnglesToRotate {
        get
        {
            return _anglesToRotate;
        }
        set
        {
            _anglesToRotate = value;
        }
    }

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

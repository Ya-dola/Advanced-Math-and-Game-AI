using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotation
{
    Vector3 CurrentRotation { get; set; }
    Vector3 AnglesToRotate { get; set; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public float ResetSpeed = 1f;
    private void Awake()
    {
        Instance = this;
    }

    public void ShowGameOverPopUp() {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public Player Player1;
    public Player Player2;
    public GameObject GameOverCanvas;
    public float ResetSpeed = 1f;
    private void Awake()
    {
        Instance = this;
    }

    public void ShowGameOverPopUp(string player)
    {
        GameOverCanvas.GetComponent<GameOver>()?.ShowGameOverCanvas(player);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public Player Player1;
    public Player Player2;
    public GameOver GameOverCanvas;
    public Score ScoreCanvas;
    public float ResetSpeed = 1f;
    private void Awake()
    {
        Instance = this;
    }

    public void GameOver(string player)
    {
        Player1.Weapon.SetActive(false);
        Player2.Weapon.SetActive(false);
        GameOverCanvas.GetComponent<GameOver>()?.ShowGameOverCanvas(player);
    }
}

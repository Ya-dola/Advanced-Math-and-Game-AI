using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Slider Player1Health;
    public Slider Player2Health;
    void Start()
    {
        LevelManager.Instance.Player1.playerHit += UpdatePlayer1Health;
        LevelManager.Instance.Player2.playerHit += UpdatePlayer2Health;
    }

    public void UpdatePlayer2Health(PlayerData playerData)
    {
        Player2Health.value = playerData.Health;
    }

    public void UpdatePlayer1Health(PlayerData playerData)
    {
        Player1Health.value = playerData.Health;
    }
}

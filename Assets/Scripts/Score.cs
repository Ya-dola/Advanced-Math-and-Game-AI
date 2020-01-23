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
        LevelManager.Instance.Player1.playerHit += Player1_playerHit;
        LevelManager.Instance.Player2.playerHit += Player2_playerHit;
    }

    private void Player2_playerHit(PlayerData playerData)
    {
        Player2Health.value = playerData.Health;
    }

    private void Player1_playerHit(PlayerData playerData)
    {
        Player1Health.value = playerData.Health;
    }
}

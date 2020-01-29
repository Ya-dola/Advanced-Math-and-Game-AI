using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPowerUp : MonoBehaviour, IPowerUp
{
    public Player player;
    public int Health = 20;
    public int ActiveFor = 0;
    public GameObject PowerUpEffect;

    public void Activate()
    {
        GetComponent<Button>().interactable = false;
        player.playerData.Health += Health;
        if(player.tag == "Player1")
        {
            LevelManager.Instance.ScoreCanvas.UpdatePlayer1Health(player.playerData);
        }
        else
        {
            LevelManager.Instance.ScoreCanvas.UpdatePlayer2Health(player.playerData);
        }
        //Instantiate(PowerUpEffect, player.transform.localPosition, Quaternion.identity);
    }
    public void Deactivate()
    {
    }

    public IEnumerator HoldActive()
    {
        yield return new WaitForSeconds(ActiveFor);
        Deactivate();
    }
}

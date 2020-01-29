using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePowerUp : MonoBehaviour, IPowerUp
{
    public Player player;
    public int Damage = 20;
    public int ActiveFor = 10;
    public Sprite regularSprite;
    public Sprite powerUpSprite;

    public void Activate()
    {
        GetComponent<Button>().interactable = false;
        player.weaponData.Damage += Damage;
        player.Weapon.GetComponent<SpriteRenderer>().sprite = powerUpSprite;
        StartCoroutine(HoldActive());
    }
    public void Deactivate()
    {
        player.weaponData.Damage -= Damage;
        player.Weapon.GetComponent<SpriteRenderer>().sprite = regularSprite;
    }

    public IEnumerator HoldActive()
    {
        yield return new WaitForSeconds(ActiveFor);
        Deactivate();
    }
}

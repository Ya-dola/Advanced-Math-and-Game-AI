using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Weapon;
    [HideInInspector]
    public PlayerData playerData;
    [HideInInspector]
    public WeaponData weaponData;

    [HideInInspector]
    public delegate void PlayerHit(PlayerData playerData);
    [HideInInspector]
    public event PlayerHit playerHit;

    private void Awake()
    {
        playerData = GetComponent<PlayerData>();
        weaponData = Weapon.GetComponent<WeaponData>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != Weapon.tag)
        {
            var opponentWeapon = collision.gameObject.GetComponent<WeaponData>();
            if(opponentWeapon != null)
            {
                TakeDamage(opponentWeapon);
            }
        }
    }

    private void TakeDamage(WeaponData opponentWeapon)
    {
        playerData.Health -= opponentWeapon.Damage;
        playerHit?.Invoke(playerData);
        if (playerData.Health <= 0)
        {
            //TODO: Change player sprite
            StartCoroutine(GameOver());
        }
        //TODO: Show particle effect - explosion
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        LevelManager.Instance.GameOver(gameObject.tag);
    }
}

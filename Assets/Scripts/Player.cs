﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Weapon;
    PlayerData playerData;
    WeaponData weaponData;

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
        if(playerData.Health <= 0)
        {
            //TODO: Change player sprite
            StartCoroutine(GameOver());
        }
        //TODO: Show particle effect - explosion
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        LevelManager.Instance.ShowGameOverPopUp(gameObject.tag);
    }
}

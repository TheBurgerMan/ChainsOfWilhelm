using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip damagedSound, shootSound, pickupSound, enemyDeathSound;

    static AudioSource src;

    private void Start()
    {
        damagedSound = Resources.Load<AudioClip>("Hurt");
        shootSound = Resources.Load<AudioClip>("Shoot");
        enemyDeathSound = Resources.Load<AudioClip>("EnemyDeath");
        pickupSound = Resources.Load<AudioClip>("Pickup");
        src = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clipName)
    {
        switch (clipName)
        {
            case "Damaged":
                src.PlayOneShot(damagedSound);
                break;
            case "Shoot":
                src.PlayOneShot(shootSound);
                break;
            case "Pickup":
                src.PlayOneShot(pickupSound);
                break;
            case "EnemyDeath":
                src.PlayOneShot(enemyDeathSound);
                break;
        }
    }
}

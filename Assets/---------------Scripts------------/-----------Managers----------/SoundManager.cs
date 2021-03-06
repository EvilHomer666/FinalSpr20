﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    // UI Sounds
    [SerializeField] AudioClip navigationBlip;
    [SerializeField] AudioClip quit;

    // Stage Music
    [SerializeField] AudioClip level_01;
    [SerializeField] AudioClip boss_01;

    // Player SFX clips
    [SerializeField] AudioClip blowShield;
    [SerializeField] AudioClip recoverShield;
    [SerializeField] AudioClip speedDown;
    [SerializeField] AudioClip speedBoost;
    [SerializeField] AudioClip dangerWarning;
    [SerializeField] AudioClip collectPowerUp;
    [SerializeField] AudioClip shootLaserLv1;
    [SerializeField] AudioClip confirmed;
    [SerializeField] AudioClip proximityWarning;
    [SerializeField] AudioClip enginesDown;
    [SerializeField] AudioClip enginesUpLv1;
    [SerializeField] AudioClip enginesUpLv2;
    [SerializeField] AudioClip enginesUpLv3;

    // TO DO Optimize how these area accessed in DetectsCollisions script
    // Enemies SFX clips
    [SerializeField] AudioClip enemyShipEngaged;
    [SerializeField] AudioClip enemyShipDestroyed;
    [SerializeField] AudioClip enemyHomingProjectile;
    // Hazards SFX clips
    [SerializeField] AudioClip asteroidHit;
    [SerializeField] AudioClip mineHit;
    [SerializeField] AudioClip asteroidDestroyed;
    [SerializeField] AudioClip mineDestroyed;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // UI sound methods
    public void NavigationBlip()
    {
        audioSource.PlayOneShot(navigationBlip, 0.5f);
        return;
    }
    public void QuitBlip()
    {
        audioSource.PlayOneShot(quit, 0.5f);
        return;
    }

    // Custom functions to access sound FXs and music tracks
    // Stage Music
    public void StageMusic_01()
    {
        audioSource.PlayOneShot(level_01, 0.5f);
        return;
    }
    public void BossMusic_01()
    {
        audioSource.PlayOneShot(boss_01, 0.5f);
        return;
    }

    // Player SFX
    public void PlayerShieldDamage()
    {
        audioSource.PlayOneShot(blowShield, 1.2f);
        return;
    }
    public void PlayerShieldUp()
    {
        audioSource.PlayOneShot(recoverShield, 0.7f);
        return;
    }
    public void PlayerSpeedDown()
    {
        audioSource.PlayOneShot(speedDown, 0.7f);
        return;
    }
    public void PlayerSpeedBoost()
    {
        audioSource.PlayOneShot(speedBoost, 0.7f);
        return;
    }
    public void PlayerDangerWarning()
    {
        audioSource.PlayOneShot(dangerWarning, 0.3f);
        return;
    }
    public void PlayerCollectedPowerUp()
    {
        audioSource.PlayOneShot(collectPowerUp, 0.5f);
        return;
    }
    public void PlayerFireLaserLv1()
    {
        audioSource.PlayOneShot(shootLaserLv1, 0.75f);
        return;
    }
    public void PlayerInputConfirmed()
    {
        audioSource.PlayOneShot(confirmed, 1.5f);
        return;
    }
    public void ProximityWarning()
    {
        audioSource.PlayOneShot(proximityWarning, 0.5f);
        return;
    }
    public void EnginesDown()
    {
        audioSource.PlayOneShot(enginesDown, 1.0f);
        return;
    }
    public void EnginesLv1()
    {
        audioSource.PlayOneShot(enginesUpLv1, 1.0f);
        return;
    }
    public void EnginesLv2()
    {
        audioSource.PlayOneShot(enginesUpLv2, 1.0f);
        return;
    }
    public void EnginesLv3()
    {
        audioSource.PlayOneShot(enginesUpLv3, 1.0f);
        return;
    }



    // Enemy SFX
    public void EnemyShipEngaged()
    {
        audioSource.PlayOneShot(enemyShipEngaged, 2.0f);
        return;
    }
    public void EnemyShipDestroyed()
    {
        audioSource.PlayOneShot(enemyShipDestroyed, 2.0f);
        return;
    }
    public void EnemyHomingProjectile()
    {
        audioSource.PlayOneShot(enemyHomingProjectile, 1.0f);
        return;
    }

    // Hazards SFX
    public void AsteroidHit()
    {
        audioSource.PlayOneShot(asteroidHit, 1.0f);
        return;
    }
    public void MineHit()
    {
        audioSource.PlayOneShot(mineHit, 0.075f);
        return;
    }
    public void AsteroidDestroyed()
    {
        audioSource.PlayOneShot(asteroidDestroyed, 1.0f);
        return;
    }
    public void MineDestroyed()
    {
        audioSource.PlayOneShot(mineDestroyed, 1.0f);
        return;
    }
}

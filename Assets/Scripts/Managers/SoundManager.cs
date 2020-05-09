using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Player SFX clips
    [SerializeField] AudioClip blowShield;
    [SerializeField] AudioClip recoverShield;
    [SerializeField] AudioClip speedDown;
    [SerializeField] AudioClip speedBoost;
    [SerializeField] AudioClip dangerWarning;
    [SerializeField] AudioClip collectPowerUp;
    [SerializeField] AudioClip shootLaserLv1;

    // TO DO Optimize how these area accessed in DetectsCollisions script
    // Enemies SFX clips
    [SerializeField] AudioClip enemyShipEngaged;
    [SerializeField] AudioClip enemyShipDestroyed;
    [SerializeField] AudioClip enemyHomingProjectile;
    // Hazards SFX clips
    [SerializeField] AudioClip largeAsteroidHit;
    [SerializeField] AudioClip smallAsteroidHit;
    [SerializeField] AudioClip largeAsteroidDestroyed;
    [SerializeField] AudioClip smallAsteroidDestroyed;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Custom functions to access sound FXs
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
        audioSource.PlayOneShot(shootLaserLv1, 1.0f);
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
    public void LargeAsteroidHit()
    {
        audioSource.PlayOneShot(largeAsteroidHit, 1.0f);
        return;
    }
    public void SmallAsteroidHit()
    {
        audioSource.PlayOneShot(smallAsteroidHit, 1.7f);
        return;
    }
    public void LargeAsteroidDestroyed()
    {
        audioSource.PlayOneShot(largeAsteroidDestroyed, 3.0f);
        return;
    }
    public void SmallAsteroidDestroyed()
    {
        audioSource.PlayOneShot(smallAsteroidDestroyed, 1.7f);
        return;
    }
}

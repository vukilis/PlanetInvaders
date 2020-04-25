using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    /// Projectile prefab for shooting

    public Transform shotPrefab;

    /// Cooldown in seconds between two shots
    public float shootingRate = 0.25f;

    // 2 - Cooldown
    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void FixedUpdate()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    /// Create a new projectile if possible
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Create a new shot 
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Assign position
            shotTransform.position = transform.position;

            // The is enemy property
            WeaponShotFire shot = shotTransform.gameObject.GetComponent<WeaponShotFire>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            // Make the weapon shot always towards it
            WeaponShotMove move = shotTransform.gameObject.GetComponent<WeaponShotMove>();
            if (move != null)
            {
                move.direction = this.transform.right; // towards in 2D space is the right of the sprite
            }
        }
    }

    /// <summary>
    /// Is the wepaon ready to create a new projectile?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotFire : MonoBehaviour
{
    /// Damage
    public int damage = 1;

    /// Nanosenje stete

    public bool isEnemyShot = false;

    void Start()
    {
        // Delay
        Destroy(gameObject, 20);
    }
}

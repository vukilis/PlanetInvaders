using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpecialEffects : MonoBehaviour
{
    /// <summary>
    /// Smoke effects
    /// </summary>
    public static SpecialEffects Instance;

    public ParticleSystem fireEffect;
    public ParticleSystem smokeEffect;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }
        Instance = this;
    }

    /// <summary>
    /// Explozija na odredjenoj poziciji
    /// </summary>

    public void Explosion(Vector3 position)
    {
        instantiate(fireEffect, position);
        instantiate(smokeEffect, position);
    }

    /// <summary>
    /// Instanca za prefab efekta
    /// </summary>
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;

        // Da je sigurno unisteno
        Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);

        return newParticleSystem;
    }
}

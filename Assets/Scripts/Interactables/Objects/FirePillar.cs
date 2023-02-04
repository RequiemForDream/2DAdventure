using System.Collections;
using UnityEngine;

public class FirePillar : DamageThing
{
    [SerializeField] private Collider2D fireCollider;
    [SerializeField] private float fireTime = 5f;
    [SerializeField] private ParticleSystem fireParticle;

    private float timeReseter => fireTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision = fireCollider;
        DamagePlayer(collision);
    }
}

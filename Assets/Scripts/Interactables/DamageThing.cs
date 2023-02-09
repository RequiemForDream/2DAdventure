using Assets.Scripts.Character.CharacterHealth;
using UnityEngine;

public abstract class DamageThing : MonoBehaviour
{
    [SerializeField] private float damage;

    protected void DamagePlayer(Collider2D collider)
    {
        if (IsCollisionDetectableObject(collider, out IHealthHandler handleHealth))
            handleHealth.ApplyDamage(this.damage, gameObject);
    }

    private bool IsCollisionDetectableObject(Collider2D collision, out IHealthHandler handleHealth)
    {
        handleHealth = collision.gameObject.GetComponent<IHealthHandler>();
        return handleHealth != null;
    }
}

using Assets.Scripts.Character.CharacterHealth;
using UnityEngine;

public abstract class DamageThing : MonoBehaviour
{
    [SerializeField] private float damage;

    protected void DamagePlayer(Collider2D collider)
    {
        if (IsCollisionDetectableObject(collider, out IHandleHealth handleHealth))
            handleHealth.ApplyDamage(this.damage);
    }

    private bool IsCollisionDetectableObject(Collider2D collision, out IHandleHealth handleHealth)
    {
        handleHealth = collision.gameObject.GetComponent<IHandleHealth>();
        return handleHealth != null;
    }
}

using Assets.Scripts.Character.CharacterHealth;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHandleHealth handleHealth = collision.GetComponent<IHandleHealth>();
        if (handleHealth != null)
        {
            handleHealth.ApplyHeal(healAmount);
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}

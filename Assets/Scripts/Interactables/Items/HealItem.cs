using Assets.Scripts.Character.Health;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealthHandler handleHealth = collision.GetComponent<IHealthHandler>();
        if (handleHealth != null)
        {
            handleHealth.ApplyHeal(healAmount, gameObject);
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}

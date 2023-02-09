using UnityEngine;

namespace Assets.Scripts.Character.CharacterHealth
{
    public class PlayerHealth : MonoBehaviour, IHealthHandler
    {
        public delegate void HealthChangedHandler(float amount);
        public event HealthChangedHandler OnHealthChanged;

        private float health;

        private void Start()
        {
            health = 100f;
        }

        public void ApplyDamage(float damage, GameObject source)
        {
            health -= damage;
            OnHealthChanged?.Invoke(health);
        }

        public void ApplyHeal(float heal, GameObject source)
        {
            health += heal;
            OnHealthChanged?.Invoke(health);
        }
    }
}


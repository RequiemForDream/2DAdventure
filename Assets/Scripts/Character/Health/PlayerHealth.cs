using Assets.Scripts.Character.Characteristics;
using UnityEngine;

namespace Assets.Scripts.Character.Health
{
    public class PlayerHealth : MonoBehaviour, IHealthHandler
    {
        public delegate void HealthChangedHandler(float amount);
        public event HealthChangedHandler OnHealthChanged;
        public event HealthChangedHandler OnMaxHealthChanged;

        [SerializeField] private CharacteristicsContainer container;

        private const string MAXHEALTH = "health";
        public float maxHealth { get; private set; }
        private float currentHealth;

        private void Start()
        {
            currentHealth = container.maxHealth;
            maxHealth = container.maxHealth;
        }

        private void Update()
        {
            maxHealth = container.maxHealth;
        }

        public void ApplyDamage(float damage, GameObject source)
        {
            currentHealth -= damage;
            OnHealthChanged?.Invoke(currentHealth);
        }

        public void ApplyHeal(float heal, GameObject source)
        {
            currentHealth += heal;
            OnHealthChanged?.Invoke(currentHealth);
        }

        private void ChangeMaxHealth(string key, float value)
        {
            if (key == MAXHEALTH)
            {
                OnMaxHealthChanged?.Invoke(value);
            }
        }

        private void OnEnable()
        {
            container.OnCharacteristicChange += ChangeMaxHealth;
        }

        private void OnDisable()
        {
            container.OnCharacteristicChange -= ChangeMaxHealth;
        }
    }
}


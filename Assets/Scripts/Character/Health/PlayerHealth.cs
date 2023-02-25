using Assets.Scripts.Character.Characteristics;
using Assets.Scripts.Character.Controller;
using System;
using UnityEngine;

namespace Assets.Scripts.Character.Health
{
    public class PlayerHealth : MonoBehaviour, IHealthHandler
    {
        public event Action<float, float> OnAnyHealthChanged;

        private CharacterMaxHealthProvider maxHealthProvider;

        private float maxHealth;
        private float currentHealth;

        private void Awake()
        {
            maxHealthProvider = new CharacterMaxHealthProvider();
            maxHealth = maxHealthProvider.maxHealth;
            currentHealth = maxHealth;
            OnAnyHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        private void OnEnable()
        {
            maxHealthProvider.OnMaxHealthChanged += SetMaxHealth;
        }

        private void OnDisable()
        {
            maxHealthProvider.OnMaxHealthChanged -= SetMaxHealth;
        }

        public void ApplyDamage(float damage, GameObject source)
        {
            currentHealth -= damage;
            OnAnyHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public void ApplyHeal(float heal, GameObject source)
        {
            currentHealth += heal;
            OnAnyHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        private void SetMaxHealth(float maxHealth)
        {
            this.maxHealth = maxHealth;
            OnAnyHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
                ApplyDamage(10, this.gameObject);

            if (Input.GetKeyDown(KeyCode.H))
                ApplyDamage(-10, this.gameObject);

            if (Input.GetKeyDown(KeyCode.I))           
                maxHealthProvider.Modify(10);                         
        }
    }
}


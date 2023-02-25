using Assets.Scripts.Character.Health;
using Assets.Scripts.UI;
using UnityEngine;

public class HealthSystemDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealthSystem;
    [SerializeField] private HealthSlider healthBar;
    [SerializeField] private HealthViewer healthViewer;

    private void OnEnable()
    {
        playerHealthSystem.OnAnyHealthChanged += SetHealth;
        playerHealthSystem.OnAnyHealthChanged += SetMaxHealth;
    }

    private void OnDisable()
    {
        playerHealthSystem.OnAnyHealthChanged -= SetHealth;
        playerHealthSystem.OnAnyHealthChanged -= SetMaxHealth;
    }

    private void SetHealth(float currentHealth, float maxHealth)
    {
        float health = currentHealth / maxHealth;
        healthBar.SetFillBar(health);
    }

    private void SetMaxHealth(float currentHealth, float maxHealth)
    {
        healthViewer.SetView(currentHealth, maxHealth);        
    }
}

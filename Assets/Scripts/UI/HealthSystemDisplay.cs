using Assets.Scripts.Character.Characteristics;
using Assets.Scripts.Character.Health;
using Assets.Scripts.UI;
using UnityEngine;

public class HealthSystemDisplay : MonoBehaviour
{
    [SerializeField] private CharacteristicsContainer container;
    [SerializeField] private PlayerHealth playerHealthSystem;
    [SerializeField] private HealthSlider healthBar;
    [SerializeField] private HealthViewer healthViewer;

    private void OnEnable()
    {
        playerHealthSystem.OnHealthChanged += SetHealth;
        playerHealthSystem.OnMaxHealthChanged += SetMaxHealth;
    }

    private void OnDisable()
    {
        playerHealthSystem.OnHealthChanged -= SetHealth;
        playerHealthSystem.OnMaxHealthChanged -= SetMaxHealth;
    }

    private void SetHealth(float health)
    {
        healthBar.SetFillBar(health);
    }

    private void SetMaxHealth(float maxHealth)
    {
        healthViewer.SetView(maxHealth);        
    }

    private void Update()
    {
        //SetMaxHealth(playerHealthSystem.maxHealth);
    }
}

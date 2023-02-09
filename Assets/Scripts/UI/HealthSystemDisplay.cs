using Assets.Scripts.Character.CharacterHealth;
using UnityEngine;

public class HealthSystemDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealthSystem;

    [SerializeField] private HealthSlider healthBar;

    private void OnEnable()
    {
        playerHealthSystem.OnHealthChanged += SetHealth;
    }

    private void OnDisable()
    {
        playerHealthSystem.OnHealthChanged -= SetHealth;
    }

    private void SetHealth(float health)
    {
        healthBar.SetFillBar(health);
    }
}

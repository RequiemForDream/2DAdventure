using UnityEngine;

namespace Assets.Scripts.Character.CharacterHealth
{
    public class Health : MonoBehaviour, IHandleHealth
    {       
        [SerializeField] private HealthBar healthBar;

        private float health;

        private void Start()
        {
            health = 100;
        }

        public void ApplyDamage(float damage)
        {
            health -= damage;
            healthBar.SetFillBar(health);
        }

        public void ApplyHeal(float heal)
        {
            health += heal;
            healthBar.SetFillBar(health);
        }
    }
}


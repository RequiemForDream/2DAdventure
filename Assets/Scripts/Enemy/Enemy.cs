using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private int health;
        public GameObject player;
        
        
        public void ApplyDamage(int damage)
        {
            health -= damage;
        }

        public void Attack(int damage)
        {
            
        }

        protected void Move(float speed, GameObject player)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - this.transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
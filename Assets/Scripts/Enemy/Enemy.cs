using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour, IEnemy
    {
        [SerializeField] private int health;
        
        public void ApplyDamage(int damage)
        {
            health -= damage;
        }

        public void Attack(int damage)
        {
            
        }

        protected void Move(CharacterController controller, Vector3 moveDirection, float speed)
        {
            controller.Move(moveDirection * speed * Time.fixedDeltaTime);
            //rigidbody2D.MovePosition(new Vector2(transform.position.x + velocity, transform.position.y));                    
        }
    }
}
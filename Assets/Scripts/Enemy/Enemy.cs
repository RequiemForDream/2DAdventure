using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private Transform rayOutPoint;
        [SerializeField] private Transform rayInPoint;
        private Ray2D ray => new Ray2D(rayOutPoint.position, Vector2.right);
        private RaycastHit2D hit => Physics2D.Raycast(rayOutPoint.position, rayInPoint.position);

        private void Awake()
        {
            
        }
        
        public void ApplyDamage(int damage)
        {
            health -= damage;
        }

        public void DoDamage(int damage)
        {
            
        }

        public void Move(Rigidbody2D rigidbody2D, Vector2 position)
        {
            Debug.DrawRay(rayOutPoint.position, rayInPoint.position, Color.red);
            if (hit.collider != null)
            {
                rigidbody2D.MovePosition(position);
            }            
        }
    }
}
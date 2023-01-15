using UnityEngine;

namespace Assets.Scripts.Enemy
{
    //[RequireComponent(typeof(Rigidbody2D))]
    public class EnemyArcher : Enemy
    {
        private new Rigidbody2D rigidbody2D;
        [SerializeField] private Vector2 destination;

        private void Awake()
        {
            //rigidbody2D = GetComponent<Rigidbody2D>();    
        }

        private void Update()
        {
            Move(rigidbody2D, destination);
        }
    }
}
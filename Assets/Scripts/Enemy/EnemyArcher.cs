using UnityEngine;

namespace Assets.Scripts.Enemy
{
    //[RequireComponent(typeof(Rigidbody2D))]
    public class EnemyArcher : Enemy
    {
        private new Rigidbody2D rigidbody2D;
        
        [SerializeField] private float velocity;
        private CharacterController controller;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            //rigidbody2D = GetComponent<Rigidbody2D>();    
        }

        private void Update()
        {
            
            
        }
    }
}
using Assets.Scripts.Character.CharacterController;
using Assets.Scripts.Interactables;
using UnityEngine;

namespace Assets.Scripts.MainCharacterController
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character : MonoBehaviour, IControllable, IClimbable
    {
        [Header("Movement")]
        [SerializeField] private float speed = 2f;
        [SerializeField] private Transform groundChecker;
        [SerializeField] private float jumpHeight = 3f;
        [SerializeField] private float checkGroundRadius = 0.4f;
        [SerializeField] private LayerMask groundMask;

        [Header("Climbing")]
        [SerializeField] private float climbSpeed = 2f;

        [Header("Swinging")]
        [SerializeField] private float swingSpeed = 0.02f;

        private new Rigidbody2D rigidbody2D;
        private bool isGrounded;

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            isGrounded = IsOnGround();
        }

        private bool IsOnGround()
        {
            bool result = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundMask);
            return result;
        }

        public void Move(Vector2 direction)
        {
            //rigidbody2D.AddForce(new Vector2(direction.x, 0) * swingSpeed * Time.deltaTime, ForceMode2D.Impulse);
            rigidbody2D.velocity = new Vector2(direction.x * speed, rigidbody2D.velocity.y);           
        }

        public void Jump()
        {
            if (isGrounded)
            {
                rigidbody2D.velocity = Vector2.up * jumpHeight;
            }
        }

        public void Climb(Vector2 direction)
        {
            rigidbody2D.velocity = new Vector2(direction.x * climbSpeed, direction.y * climbSpeed);
        }

        public void Swing(Vector2 direction)
        {
            //rigidbody2D.AddForce(new Vector2(direction.x, 0) * swingSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}



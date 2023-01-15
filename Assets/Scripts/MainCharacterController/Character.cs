using UnityEngine;

namespace Assets.Scripts.MainCharacterController
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, IControllable
    {
        [Header("Character Settings")]
        [SerializeField] private float speed = 10f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private Transform groundChecker;
        [SerializeField] private float jumpHeight = 3f;
        [SerializeField] private float checkGroundRadius = 0.4f;
        [SerializeField] private LayerMask groundMask;

        private CharacterController controller;
        private float velocity;
        private Vector3 moveDirection;
        private bool isGrounded;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            isGrounded = IsOnGround();

            if (isGrounded && velocity < 0)
            {
                velocity = -2;
            }

            MoveInternal();
            DoGravity();
        }

        private bool IsOnGround()
        {
            bool result = Physics.CheckSphere(groundChecker.position, checkGroundRadius, groundMask);
            return result;
        }

        public void Move(Vector3 direction)
        {
            moveDirection = direction;
        }

        public void Jump()
        {
            if (isGrounded)
            {
                velocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }
        }

        private void MoveInternal()
        {
            controller.Move(moveDirection * speed * Time.fixedDeltaTime);
        }

        private void DoGravity()
        {
            velocity += gravity * Time.fixedDeltaTime;

            controller.Move(Vector3.up * velocity * Time.fixedDeltaTime);
        }
    }
}


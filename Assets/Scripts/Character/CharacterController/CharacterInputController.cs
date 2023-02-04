using UnityEngine;
using System;
using Assets.Scripts.Interactables;
using Assets.Scripts.Character.Colliders;
using Assets.Scripts.Character.CharacterController;

namespace Assets.Scripts.MainCharacterController
{
    public class CharacterInputController : MonoBehaviour
    {
        [SerializeField] private GrapplingHook grapplingHook;

        private IControllable controllable;
        private IClimbable climbable;
        private IPlatformable platformable;
        private IHookable hookable;

        private void Awake()
        {
            controllable = GetComponent<IControllable>();
            climbable = GetComponent<IClimbable>();
            platformable = GetComponentInChildren<IPlatformable>();
            hookable = GetComponent<IHookable>();

            if (controllable == null )
            {
                throw new Exception($"There is no IControllable component on the object: {gameObject.name}");
            }
        }

        private void Update()
        {           
            ReadJump();
            GetDown();
            CreateHook();
            DisableHook();
            ClimbHook();
            DescendHook();
        }

        private void FixedUpdate()
        {
            ReadMove();
            ReadClimb();
        }

        private void ReadMove()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var direction = new Vector2(horizontal, 0f);

            controllable.Move(direction);
        }

        private void ReadJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                controllable.Jump();
            }
        }

        private void ReadClimb()
        {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");
            var direction = new Vector2(horizontal, vertical);

            if (LadderChecker.isAbleToClimb)
            {
                climbable.Climb(direction);
            }           
        }

        private void GetDown()
        {
            if (platformable.isOnPlatform == true)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    platformable.TurnOffTrigger();
                }
            }
        }

        private void CreateHook()
        {           
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                grapplingHook.CreateHook();
            }
        }

        private void DisableHook()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                grapplingHook.Disable();
            }
        }

        private void ClimbHook()
        {
            if (Input.GetKey(KeyCode.W))
            {
                grapplingHook.Climb();
            }
        }

        private void DescendHook()
        {
            if (Input.GetKey(KeyCode.S))
            {
                grapplingHook.Descend();
            }
        }
    }
}
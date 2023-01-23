using UnityEngine;
using System;
using Assets.Scripts.Interactables.Opening;
using Assets.Scripts.Interactables;

namespace Assets.Scripts.MainCharacterController
{
    public class CharacterInputController : MonoBehaviour
    {
        private IControllable controllable;
        private IClimbable climbable;

        private void Awake()
        {
            controllable = GetComponent<IControllable>();
            climbable = GetComponent<IClimbable>();

            if (controllable == null )
            {
                throw new Exception($"There is no IControllable component on the object: {gameObject.name}");
            }
        }

        private void Update()
        {           
            ReadJump();
            ReadOpen();
            
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

        private void ReadOpen()
        {
            if (Opening.isAbleToOpen)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                   
                }
            }
        }

        private void ReadClimb()
        {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");
            var direction = new Vector2(horizontal, vertical);

            if (Climbing.isAbleToClimb)
            {
                climbable.Climb(direction);
            }           
        }
    }
}
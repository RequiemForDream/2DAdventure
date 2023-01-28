﻿using UnityEngine;
using System;
using Assets.Scripts.Interactables;
using Assets.Scripts.Character.Colliders;

namespace Assets.Scripts.MainCharacterController
{
    public class CharacterInputController : MonoBehaviour
    {
        private IControllable controllable;
        private IClimbable climbable;
        private IPlatformable platformable;

        private void Awake()
        {
            controllable = GetComponent<IControllable>();
            climbable = GetComponent<IClimbable>();
            platformable = GetComponentInChildren<IPlatformable>();

            if (controllable == null )
            {
                throw new Exception($"There is no IControllable component on the object: {gameObject.name}");
            }
        }

        private void Update()
        {           
            ReadJump();
            GetDown();
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
    }
}
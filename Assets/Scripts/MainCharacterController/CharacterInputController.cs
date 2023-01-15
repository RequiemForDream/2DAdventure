using UnityEngine;
using System;

namespace Assets.Scripts.MainCharacterController
{
    public class CharacterInputController : MonoBehaviour
    {
        private IControllable controllable;

        private void Awake()
        {
            controllable = GetComponent<IControllable>();

            if (controllable == null )
            {
                throw new Exception($"There is no IControllable component on the object: {gameObject.name}");
            }
        }

        private void Update()
        {
            ReadMove();
            ReadJump();
        }

        private void ReadMove()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var direction = new Vector3(horizontal, 0f, 0f);

            controllable.Move(direction);
        }

        private void ReadJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                controllable.Jump();
            }
        }
    }
}
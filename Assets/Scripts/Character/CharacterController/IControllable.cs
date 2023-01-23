using UnityEngine;

namespace Assets.Scripts.MainCharacterController
{
    public interface IControllable
    {
        void Move(Vector2 direction);
        void Jump();
    }
}

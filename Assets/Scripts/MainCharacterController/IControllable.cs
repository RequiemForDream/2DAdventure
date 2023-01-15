using UnityEngine;

namespace Assets.Scripts.MainCharacterController
{
    public interface IControllable
    {
        void Move(Vector3 direction);
        void Jump();
    }
}

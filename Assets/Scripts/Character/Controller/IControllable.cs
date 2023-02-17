using UnityEngine;

namespace Assets.Scripts.Controller
{
    public interface IControllable
    {
        void Move(Vector2 direction);
        void Jump();
    }
}

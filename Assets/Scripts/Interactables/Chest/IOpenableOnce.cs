using UnityEngine;

namespace Assets.Scripts.Interactables.Opening
{
    public interface IOpenableOnce
    {
        bool isOpened { get; }
        void Open();
    }
}
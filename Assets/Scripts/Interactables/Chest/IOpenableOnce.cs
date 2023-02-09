using UnityEngine;

namespace Assets.Scripts.Interactables.Opening
{
    public interface IOpenableOnce
    {
        void Detected(GameObject source);
    }
}
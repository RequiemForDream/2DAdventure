using UnityEngine;

namespace Assets.Scripts.Controller.Opening
{
    public interface IOpenableOnce
    {
        void Detected(GameObject source);
    }
}
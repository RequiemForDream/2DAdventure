using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public abstract class Mediator : MonoBehaviour
    {
        public abstract void Send(Interactor sender, int amount);              
    }
}


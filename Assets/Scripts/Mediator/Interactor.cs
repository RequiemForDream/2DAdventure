using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public delegate void OnAmountChanged(GameObject sender, int amount);

    public abstract class Interactor : MonoBehaviour
    {
        [SerializeField] protected Mediator mediator;

        public Interactor(Mediator mediator)
        {
            this.mediator = mediator;
        }

        protected virtual void Send(int amount)
        {
            mediator.Send(this, amount);
        }

        public abstract void Notify(int amount);                       
    }
}
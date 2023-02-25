using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public abstract class Interactor : MonoBehaviour
    {       
        [SerializeField] protected Mediator mediator;

        public Interactor(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(GameObject sender, int amount)
        {
            mediator.Send(this, amount);
        }

        public abstract void Notify(int amount); 
    }
}
using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class GemsInteractor : Interactor
    {
        public GemsInteractor(Mediator mediator) : base(mediator) { }

        public override void Notify(int amount)
        {
            Debug.Log("Amount of collected gems: " + amount);
        }
    }
}
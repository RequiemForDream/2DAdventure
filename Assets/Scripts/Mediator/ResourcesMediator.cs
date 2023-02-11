using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class ResourcesMediator : Mediator
    {
        public Interactor gemInteractor;
        public Interactor coinsInteractor;

        public override void Send(Interactor sender, int amount)
        {
            if (coinsInteractor == sender)
            {
                coinsInteractor.Notify(amount);
            }

            if (gemInteractor == sender)
            {
                gemInteractor.Notify(amount);
            }
        }
    }
}
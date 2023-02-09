using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class ManagerMediator : Mediator
    {
        [SerializeField] private GemsInteractor gemInteractor;
        [SerializeField] private CoinsInteractor coinsInteractor;

        public override void Send(Interactor sender, int amount)
        {
            if (gemInteractor == sender)
            {
                gemInteractor.Notify(amount);
            }          

            if (coinsInteractor == sender)
            {
                coinsInteractor.Notify(amount);
            }
        }
    }
}
using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class CoinsInteractor : Interactor
    {
        public event OnAmountChanged OnCoinsAmountChanged;

        private void OnEnable()
        {
            OnCoinsAmountChanged += ChangeAmount;
        }

        private void OnDisable()
        {
            OnCoinsAmountChanged -= ChangeAmount;
        }

        private void ChangeAmount(GameObject sender, int amount)
        {
            Send(amount);
        }

        public CoinsInteractor(Mediator mediator) : base(mediator) 
        {

        }

        public override void Notify(int amount)
        {
            Debug.Log("Amount of collected coins: " + amount);
        }
    }
}
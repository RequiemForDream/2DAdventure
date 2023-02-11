using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class CoinsInteractor : Interactor 
    {
        [SerializeField] private Viewer moneyViewer;

        private int coinsAmount;

        private void Awake()
        {
            coinsAmount = 0;
        }

        public CoinsInteractor(Mediator mediator) : base(mediator) { }

        public override void Notify(int amount)
        {
            coinsAmount += amount;
            moneyViewer.SetView(coinsAmount);
        }
    }
}
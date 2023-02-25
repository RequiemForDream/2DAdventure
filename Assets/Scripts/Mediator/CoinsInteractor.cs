using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class CoinsInteractor : Interactor, IValueHandler
    {
        public int value => coinsAmount;
    
        [SerializeField] private Viewer moneyViewer;

        public int coinsAmount { get; private set; } 

        public CoinsInteractor(Mediator mediator) : base(mediator) { }

        private void Start()
        {
            coinsAmount = 10;
            moneyViewer.SetView(coinsAmount);
        }  

        public override void Notify(int amount)
        {
            coinsAmount += amount;
            moneyViewer.SetView(coinsAmount);
            Debug.Log(coinsAmount);
        }
    }
}
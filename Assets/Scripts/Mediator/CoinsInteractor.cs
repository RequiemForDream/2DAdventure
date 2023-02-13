using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class CoinsInteractor : Interactor, IValueHandler
    {
        public event Action OnBought;

        public int value => coinsAmount;
    

        [SerializeField] private Viewer moneyViewer;

        private int coinsAmount;

        public CoinsInteractor(Mediator mediator) : base(mediator) { }

        private void Awake()
        {
            coinsAmount = 0;
        }      

        public override void Notify(int amount)
        {
            coinsAmount += amount;
            moneyViewer.SetView(coinsAmount);
            Debug.Log(coinsAmount);
        }
    }
}
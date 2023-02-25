using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class GemsInteractor : Interactor
    {
        public int gemsAmount { get; private set; } 

        [SerializeField] private Viewer gemsViewer;

        private void Start()
        {
            gemsAmount = 2;
            gemsViewer.SetView(gemsAmount);
        }

        public GemsInteractor(Mediator mediator) : base(mediator) { }

        public override void Notify(int amount)
        {
            gemsAmount += amount;
            gemsViewer.SetView(gemsAmount);
        }
    }
}
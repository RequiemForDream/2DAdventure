using UnityEngine;

namespace Assets.Scripts.Mediator
{
    public class GemsInteractor : Interactor
    {
        private void Start()
        {
            Send(15);
        }

        public GemsInteractor(Mediator mediator) : base(mediator) { }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Notify(8);
            }
        }

        public override void Notify(int amount)
        {
            Debug.Log("Amount of collected gems: " + amount);
        }
    }
}
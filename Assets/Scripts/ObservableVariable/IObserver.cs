using System;

namespace Assets.Scripts.ObservableVariable
{
    public interface IObserver : IDisposable
    {
        void AddObservable(IObservable observable);
    }
}
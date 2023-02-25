using System;

namespace Assets.Scripts.ObservableVariable
{
    public interface IObservable
    {
        event Action<object> OnChanged;
    }
}


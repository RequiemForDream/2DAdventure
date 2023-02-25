using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObservableVariable
{
    public class ObservableLogger : MonoBehaviour, IObserver
    {
        private List<IObservable> observables;

        public ObservableLogger() 
        {
            observables = new List<IObservable>();
        }

        public ObservableLogger(IObservable observable)
        {
            observables = new List<IObservable> { observable };
            observable.OnChanged += OnChanged;
        }

        public ObservableLogger(IObservable[] _observables)
        {
            observables = new List<IObservable>(_observables);
            foreach (var observable in observables)
            {
                observable.OnChanged += OnChanged;
            }
        }


        public void AddObservable(IObservable observable)
        {
            if (observables.Contains(observable))
            {
                return;
            }

            observables.Add(observable);
            observable.OnChanged += OnChanged;
        }

        public void Dispose()
        {
            foreach (var observable in observables)
            {
                observable.OnChanged -= OnChanged;
            }
        }

        private void OnChanged(object o)
        {
            Debug.Log($"{o.GetType().Name} value changed. New value {o.ToString()}");
        }
    }
}
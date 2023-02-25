using System.Collections;
using UnityEngine;

namespace Assets.Scripts.ObservableVariable
{
    public class ObservableExample : MonoBehaviour
    {
        private ObservableVariable<int> observableVariableInt;
        private ObservableVariable<bool> observableVariableBool;
        private ObservableLogger logger;

        private void Start()
        {
            observableVariableInt = new ObservableVariable<int>(10);
            observableVariableBool = new ObservableVariable<bool>(false);

            logger = new ObservableLogger(observableVariableInt);
            logger.AddObservable(observableVariableBool);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {

            }
        }
    }
}
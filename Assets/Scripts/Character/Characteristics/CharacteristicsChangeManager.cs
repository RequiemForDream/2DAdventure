using Assets.Scripts.Character.Controller;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character.Characteristics
{
    public class CharacteristicsChangeManager : MonoBehaviour
    {              
        [SerializeField] private CharacterStats container;
        private Dictionary<string, float> _characteristics => container.characteristics;

        private void OnEnable()
        {
            CharacteristicChanger.OnCharacteristicChange += Change;
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            container.Awake();
        }

        private void Change(string key, ChangeType type, float valueToChange,  GameObject sender)
        {
            //if (!_characteristics.ContainsKey(key)) 
           // {
          //      throw new Exception($"There is a mistake in {key}! Check {key} name!");
           // }           

            switch (type)
            {
                case ChangeType.Add:                   
                        _characteristics[key] += valueToChange;                   
                        break;

                case ChangeType.Multiply:                    
                        _characteristics[key] *= valueToChange;                   
                        break;

                case ChangeType.Divide:                  
                        _characteristics[key] /= valueToChange;                                      
                        break;

                case ChangeType.Substract:                    
                        _characteristics[key] -= valueToChange;                   
                        break;
            }
            Debug.Log(_characteristics[key]);
            container.SendCharactristicChanged(key, valueToChange);
            Debug.Log("Change");
        }

        private void OnDisable()
        {
            CharacteristicChanger.OnCharacteristicChange -= Change;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character.Characteristics
{
    public class CharacteristicsContainer : MonoBehaviour
    {
        public event Action<string, float> OnCharacteristicChange;

        [Header("Characteristics")]
        [SerializeField] internal float maxHealth = 100f;
        public float hookLength = 8f;

        public Dictionary<string, float> characteristics;

        private void Awake()
        {
            characteristics = new Dictionary<string, float>
            {
                { "health", maxHealth },
                { "hookLenght", hookLength },
            };
        }

        internal void SendCharactristicChanged(string key, float value)
        {
            OnCharacteristicChange?.Invoke(key, value);
        }
    }
}
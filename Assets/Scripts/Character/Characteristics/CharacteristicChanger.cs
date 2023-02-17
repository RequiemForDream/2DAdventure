using System;
using UnityEngine;

namespace Assets.Scripts.Character.Characteristics
{
    public class CharacteristicChanger : MonoBehaviour
    {
        public static event Action<string, ChangeType, float, GameObject> OnCharacteristicChange;

        public string key;
        public ChangeType type;
        public float valueToChange;

        public void ChangeCharacteristic()
        {
            OnCharacteristicChange?.Invoke(key, type, valueToChange, this.gameObject);
        }
    }
}
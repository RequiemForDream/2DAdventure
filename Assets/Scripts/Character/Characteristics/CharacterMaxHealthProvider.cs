using System;
using UnityEngine;

namespace Assets.Scripts.Character.Characteristics
{
    public class CharacterMaxHealthProvider : IValueModificator
    {
        public event Action<float> OnMaxHealthChanged;

        public float maxHealth = 100f;

        public void Modify(float value) 
        {
            maxHealth += value;
            OnMaxHealthChanged?.Invoke(maxHealth);
        }     
    }
}
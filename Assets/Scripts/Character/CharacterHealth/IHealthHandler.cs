﻿using UnityEngine;

namespace Assets.Scripts.Character.CharacterHealth
{
    public interface IHealthHandler 
    {
        void ApplyDamage(float damage, GameObject source);
        void ApplyHeal(float heal, GameObject source);
    }
}
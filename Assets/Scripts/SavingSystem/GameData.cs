using System;
using UnityEngine;

namespace Assets.Scripts.SavingSystem
{
    [Serializable]
    public class GameData 
    {
        public int speed = 10;
        public Vector3 position;
        public Quaternion rotation;

        public GameData() 
        {
            speed = 10;
            position = Vector3.up;
            rotation = Quaternion.identity;
        }

    }
}
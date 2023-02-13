using UnityEngine;

namespace Assets.Scripts.Character.CharacterController
{
    public class CharacteristicChanger : MonoBehaviour
    {
        [SerializeField]

        private void ChangeCharacteristic<T>(StatType type, T value)
        {
            switch (type)
            {
                case StatType.HookLength:
                    break;

            }
        }
    }
}
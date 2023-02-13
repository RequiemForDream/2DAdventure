namespace Assets.Scripts.Character.CharacterController
{
    public class PlayerStats
    {
        
        public float hookLength = 8f;
        public float maxHealth = 100;

        public void ChangeCharacteristic<T>(StatType type, float value)
        {
            switch (type)
            {
                case StatType.HookLength:
                    hookLength += value;
                    break;
                case StatType.MaxHealth:
                    maxHealth += value;
                    break;
            }
        }
    }

    public enum StatType
    {
        HookLength,
        MaxHealth,
    }
}
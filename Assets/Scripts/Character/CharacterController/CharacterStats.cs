using UnityEngine;


namespace Assets.Scripts.Character.CharacterController
{
    [CreateAssetMenu(fileName = "CharacterStats", menuName = "CharacterStats")]
    public class CharacterStats : ScriptableObject
    {
        public float speed = 2f;
        public float jumpStrength = 6.5f;
        public float ropeLength = 6f;
        public float maxHealth = 100f;
    }
}
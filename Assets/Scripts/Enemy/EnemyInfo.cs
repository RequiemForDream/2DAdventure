using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "EnemyInfo", menuName = "GamePlay/NewEnemyInfo")]
    public class EnemyInfo : ScriptableObject
    {
        [SerializeField] private string _name;
        public new string name => this._name;
        [SerializeField] private int _health;
        public int health => this._health;
        [SerializeField] private int _damage;
        public int damage => this._damage;  
    }
}
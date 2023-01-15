
namespace Assets.Scripts.Enemy
{
    public interface IEnemy
    {
        void ApplyDamage(int damage);
        void Move();
        void DoDamage(int damage);
    }
}


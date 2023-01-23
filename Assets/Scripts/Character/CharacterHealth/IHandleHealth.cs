namespace Assets.Scripts.Character.CharacterHealth
{
    public interface IHandleHealth 
    {
        void ApplyDamage(float damage);

        void ApplyHeal(float heal);
    }
}
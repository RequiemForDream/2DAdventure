namespace Assets.Scripts.Character.Colliders
{
    public interface IPlatformable 
    {
        bool isOnPlatform { get; }
        void TurnOffTrigger();
    }
}
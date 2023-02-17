namespace Assets.Scripts.Character.Interactive
{
    public interface IPlatformable 
    {
        bool isOnPlatform { get; }
        void TurnOffTrigger();
    }
}
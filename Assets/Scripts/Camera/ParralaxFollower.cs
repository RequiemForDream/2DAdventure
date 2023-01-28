using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class ParralaxFollower : Follower
    {
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }
    }
}
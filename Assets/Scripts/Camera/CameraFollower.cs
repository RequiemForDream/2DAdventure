using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraFollower : Follower
    {
        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }
    }
}
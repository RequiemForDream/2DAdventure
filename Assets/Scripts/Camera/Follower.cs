using UnityEngine;

namespace Assets.Scripts.Camera
{
    public abstract class Follower : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothing = 1f;

        protected void Move(float deltaTime)
        {
            var nextPosition = Vector3.Lerp(transform.position, targetTransform.position + offset, deltaTime * smoothing);

            transform.position = nextPosition;
        }
    }
}
using UnityEngine;

namespace Assets.Scripts.Enemy.Detector
{
    public class DetectableObject : MonoBehaviour, IDetectableObject
    {
        public event ObjectDetectedHandler OnGameObjectDetectEvent;
        public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        public void Detected(GameObject detectionSource)
        {
            Debug.Log("U are in");

            OnGameObjectDetectEvent?.Invoke(detectionSource, gameObject);
        }

        public void DetectionReleased(GameObject detectionSource)
        {
            Debug.Log("U are out");

            OnGameObjectDetectionReleasedEvent?.Invoke(detectionSource, gameObject);
        }
    }
}
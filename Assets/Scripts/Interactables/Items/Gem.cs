using Assets.Scripts.Enemy.Detector;
using UnityEngine;

namespace Assets.Scripts.Interactables.Items
{
    public class Gem : MonoBehaviour, IDetectableObject
    {
        public event ObjectDetectedHandler OnGameObjectDetectEvent;
        public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        public void Detected(GameObject detectionSource)
        {
            OnGameObjectDetectEvent?.Invoke(detectionSource, this.gameObject);
        }

        public void DetectionReleased(GameObject detectionSource)
        {
            OnGameObjectDetectEvent?.Invoke(detectionSource, this.gameObject);
        }
    }
}


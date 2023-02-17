using Assets.Scripts.Enemy.Detector;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Character.Interactive
{
    [RequireComponent(typeof(Collider2D))]
    public class ChestDetector : MonoBehaviour, IDetector
    {
        public event ObjectDetectedHandler OnGameObjectDetectedEvent;
        public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

        public GameObject[] detectedObjects => _detectedObjects.ToArray();

        private List<GameObject> _detectedObjects = new List<GameObject>();

        public void Detect(IDetectableObject detectableObject)
        {
            if (!_detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.Detected(gameObject);
                _detectedObjects.Add(detectableObject.gameObject);

                OnGameObjectDetectedEvent?.Invoke(gameObject, detectableObject.gameObject);
            }
        }

        public void ReleaseDetection(IDetectableObject detectableObject)
        {
            if (_detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.Detected(gameObject);
                detectableObject.DetectionReleased(gameObject);
                _detectedObjects.Remove(detectableObject.gameObject);

                OnGameObjectDetectionReleasedEvent?.Invoke(gameObject, detectableObject.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (IsColliderDetectableObject(collision, out IDetectableObject detectableObject))
            {
                Detect(detectableObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsColliderDetectableObject(collision, out IDetectableObject detectableObject))
            {
                ReleaseDetection(detectableObject);
            }
        }

        private bool IsColliderDetectableObject(Collider2D collider, out IDetectableObject detectedObject)
        {
            detectedObject = collider.GetComponent<IDetectableObject>();
            return detectedObject != null;
        }

        public void Detect(GameObject detectedObject)
        {
            throw new System.NotImplementedException();
        }

        public void ReleaseDetection(GameObject detectedObject)
        {
            throw new System.NotImplementedException();
        }
    }
}


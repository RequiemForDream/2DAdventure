using UnityEngine;

namespace Assets.Scripts.Enemy.Detector
{
    [RequireComponent(typeof(DetectableObject))]
    public class DetectableObjectReaction : MonoBehaviour
    {
        private IDetectableObject detectableObject;

        private void Awake()
        {
            detectableObject = GetComponent<IDetectableObject>();
        }

        private void OnEnable()
        {
            detectableObject.OnGameObjectDetectEvent += OnGameObjectDetect;
            detectableObject.OnGameObjectDetectionReleasedEvent += OnGameObjectDetectionReleased;
        }

        private void OnDisable()
        {
            detectableObject.OnGameObjectDetectEvent -= OnGameObjectDetect;
            detectableObject.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetectionReleased;
        }

        private void OnGameObjectDetect(GameObject source, GameObject detectedObject)
        {

        }

        private void OnGameObjectDetectionReleased(GameObject source, GameObject detectedObject)
        {

        }
    }
}
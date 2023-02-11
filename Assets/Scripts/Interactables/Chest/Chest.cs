using UnityEngine;
using Assets.Scripts.Enemy.Detector;

[RequireComponent(typeof(Collider2D))]
public class Chest : MonoBehaviour, IDetectableObject
{
    public event ObjectDetectedHandler OnGameObjectDetectEvent;
    public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

    public void Detected(GameObject detectionSource)
    {
        OnGameObjectDetectEvent?.Invoke(detectionSource, gameObject);
    }

    public void DetectionReleased(GameObject detectionSource)
    {
        OnGameObjectDetectionReleasedEvent?.Invoke(detectionSource, gameObject);
    }
}

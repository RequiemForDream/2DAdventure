﻿using Assets.Scripts.Interactables.Opening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy.Detector
{   
    public class Detector : MonoBehaviour, IDetector
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

        public void Detect(GameObject detectedObject)
        {
            if (!_detectedObjects.Contains(detectedObject))
            {
                _detectedObjects.Add(detectedObject);

                OnGameObjectDetectedEvent?.Invoke(detectedObject, detectedObject);
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

        public void ReleaseDetection(GameObject detectedObject)
        {
            if (_detectedObjects.Contains(detectedObject))
            {
                _detectedObjects.Remove(detectedObject);

                OnGameObjectDetectionReleasedEvent?.Invoke(gameObject, detectedObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            
        }

        private bool isColliderDetectableObject(Collider2D collider, out IDetectableObject detectedObject)
        {
            detectedObject = collider.GetComponent<IDetectableObject>();
            return detectedObject!= null;
        }
    }
}
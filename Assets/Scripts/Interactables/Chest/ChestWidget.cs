using Assets.Scripts.Enemy.Detector;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interactables.Chest
{
    public class ChestWidget : MonoBehaviour
    {
        public event Action OnFilledImage;

        [SerializeField] private float timeToFilling = 0.1f;
        [SerializeField] private Image widget;

        private IDetectableObject detectableObject;       
        private bool isEnteredByPlayer;

        private void Awake()
        {
            detectableObject = GetComponentInParent<IDetectableObject>();
        }

        private void Update()
        {
            switch (isEnteredByPlayer)
            {
                case true:
                    widget.fillAmount += timeToFilling * Time.deltaTime;
                    if (widget.fillAmount == 1f)
                        OnFilledImage.Invoke();
                        OnDestroy();
                    break;
                case false:
                    break;
            }                
        }

        private void OnEnable()
        {
            detectableObject.OnGameObjectDetectEvent +=
                (GameObject source, GameObject detectedObject) => isEnteredByPlayer = true;

                detectableObject.OnGameObjectDetectionReleasedEvent += 
                    (GameObject source, GameObject detectedObject) => isEnteredByPlayer = false;
        }

        private void OnDisable()
        {
            detectableObject.OnGameObjectDetectEvent -= 
                (GameObject source, GameObject detectedObject) => isEnteredByPlayer = true; 

            detectableObject.OnGameObjectDetectionReleasedEvent -=
                    (GameObject source, GameObject detectedObject) => isEnteredByPlayer = false;
        }

        private void OnDestroy()
        {
            Destroy(gameObject, 5);
        }
    }
}
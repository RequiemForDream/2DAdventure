using Assets.Scripts.Enemy.Detector;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controller.Chest
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
                        {
                            OnFilledImage.Invoke();
                            Destroy(gameObject);
                        }
                    break;

                case false:
                    widget.fillAmount -= timeToFilling * Time.deltaTime;
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
    }
}
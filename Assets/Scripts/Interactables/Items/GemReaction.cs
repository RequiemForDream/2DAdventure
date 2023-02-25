using Assets.Scripts.Enemy.Detector;
using Assets.Scripts.Mediator;
using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interactables.Items
{
    public class GemReaction : MonoBehaviour
    {
        [Header("Mediator")]
        [SerializeField] private Interactor _gemInteractor;
        [SerializeField] private ResourcesMediator resourcesMediator;

        [SerializeField] private RectTransform gemRepository;
        [Space(10)]
        [SerializeField] private int gemsAmount = 1;

        private IDetectableObject detectableObject;
        private Collider2D gemCollider2D;
        private UnityEngine.Camera mainCamera;

        private void Awake()
        {
            detectableObject = GetComponent<IDetectableObject>();
            gemCollider2D = GetComponent<Collider2D>();
            mainCamera = UnityEngine.Camera.main;
        }

        private void OnEnable()
        {
            detectableObject.OnGameObjectDetectEvent += (GameObject source, GameObject detectedObject) =>
            StartCoroutine(IncreaseGemAmount());
        }

        private void OnDisable()
        {
            detectableObject.OnGameObjectDetectEvent -= (GameObject source, GameObject detectedObject) =>
            StartCoroutine(IncreaseGemAmount());
        }
        private IEnumerator IncreaseGemAmount()
        {
            gemCollider2D.enabled = false;

            Vector3 point = mainCamera.ScreenToWorldPoint(new Vector3(gemRepository.position.x,
                gemRepository.position.y + Screen.height,
                gemRepository.position.z));

            transform.DOMove(point, 1);

            yield return new WaitForSeconds(1);

            SendToMediator();
        }

        private void SendToMediator()
        {
            resourcesMediator.gemInteractor = _gemInteractor;
            _gemInteractor.Send(this.gameObject, gemsAmount);
        }
    }
}
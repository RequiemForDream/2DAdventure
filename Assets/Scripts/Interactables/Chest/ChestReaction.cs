using Assets.Scripts.Mediator;
using UnityEngine;

namespace Assets.Scripts.Controller.Chest
{
    public class ChestReaction : MonoBehaviour
    {
        [SerializeField] private ChestInfo chestInfo;
        [SerializeField] private ChestWidget chestWidget;
        [SerializeField] private ResourcesMediator resourcesMediator;
        [SerializeField] private Interactor _coinsInteractor;

        [SerializeField] private Animator animator;
        private Collider2D chestCollider;
        private readonly int openHash = Animator.StringToHash("isOpened");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            chestCollider = GetComponent<Collider2D>();           
        }

        private void OnEnable()
        {
            chestWidget.OnFilledImage += OpenChest;
        }

        private void OnDisable()
        {
            chestWidget.OnFilledImage -= OpenChest;       
        }

        private void OpenChest()
        {
            animator.SetBool(openHash, true);
            resourcesMediator.coinsInteractor = _coinsInteractor;
            _coinsInteractor.Send(this.gameObject, chestInfo.reward);
            chestCollider.enabled = false;
            Debug.Log("Opened");
        }
    }
}
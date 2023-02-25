using Assets.Scripts.Mediator;
using UnityEngine;

namespace Assets.Scripts.Controller.Chest
{
    public class ChestReaction : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ChestInfo chestInfo;
        [SerializeField] private ChestWidget chestWidget;
        [SerializeField] private ResourcesMediator resourcesMediator;
        [SerializeField] private Interactor coinsInteractor;

        private Animator chestAnimator;
        private Collider2D chestCollider;
        private readonly int openHash = Animator.StringToHash("isOpened");

        private void Awake()
        {
            chestAnimator = GetComponent<Animator>();
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
            chestAnimator.SetBool(openHash, true);
            resourcesMediator.coinsInteractor = this.coinsInteractor;
            coinsInteractor.Send(this.gameObject, chestInfo.reward);
            chestCollider.enabled = false;
            Debug.Log("Opened");
        }
    }
}
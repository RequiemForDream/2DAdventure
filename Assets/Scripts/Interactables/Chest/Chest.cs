using UnityEngine;
using Assets.Scripts.Interactables.Opening;
using Assets.Scripts.Mediator;

[RequireComponent(typeof(Collider2D))]
public class Chest : MonoBehaviour, IOpenableOnce
{
    [SerializeField] private ChestInfo chestInfo;
    [SerializeField] private CoinsInteractor coinsInteractor;
    [SerializeField] private Vector2 newChestPosition;
    
    private Animator animator;
    private Collider2D chestCollider;
    private readonly int openHash = Animator.StringToHash("isOpened");   

    private void Start()
    {
        animator = GetComponent<Animator>();
        chestCollider = GetComponent<Collider2D>();
    }

    public void Detected(GameObject sender)
    {
        Open();
    }

    private void Open()
    {
        animator.SetBool(openHash, true);
        chestCollider.enabled = false;
        gameObject.transform.position = newChestPosition;
        EventManager.SendMoneyChanged(chestInfo.reward);
    }   
}

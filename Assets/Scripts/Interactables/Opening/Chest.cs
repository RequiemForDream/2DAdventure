using UnityEngine;
using Assets.Scripts.Interactables.Opening;

public class Chest : MonoBehaviour, IOpenable
{
    [SerializeField] private ChestInfo chestInfo;
    public bool isOpened { get; private set; }

    private Animator animator;

    private int OpenHash = Animator.StringToHash("isOpened");
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        isOpened = true;
        animator.SetBool(OpenHash, true);
        EventManager.SendMoneyChanged(chestInfo.reward);
    }
}

using UnityEngine;
using Assets.Scripts.Interactables.Opening;

public class Chest : MonoBehaviour, IOpenableOnce
{
    public bool isOpened { get => _isOpened; }
    [SerializeField] private ChestInfo chestInfo;
    
    private Animator animator;
    private int OpenHash = Animator.StringToHash("isOpened");
    private bool _isOpened;  

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleState()
    {
        _isOpened = !_isOpened;
    }

    public void Open()
    {
        _isOpened = true;
        animator.SetBool(OpenHash, true);
        EventManager.SendMoneyChanged(chestInfo.reward);
    }
}

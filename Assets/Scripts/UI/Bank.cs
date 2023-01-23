using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private MoneyViewer moneyViewer;

    private int moneyAmount;

    private void Start()
    {
        moneyAmount = 0;
        EventManager.OnMoneyChanged += SetMoney;
    }

    private void SetMoney(int moneyAmount)
    {
        this.moneyAmount += moneyAmount;
        moneyViewer.SetMoney(this.moneyAmount);
    }
}

using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class MoneyViewer : MonoBehaviour
{
    private TMP_Text moneyView;

    private void Start()
    {
        moneyView = GetComponent<TMP_Text>();
    }

    public void SetMoney(int amount)
    {
        moneyView.text = amount.ToString();
    }
}

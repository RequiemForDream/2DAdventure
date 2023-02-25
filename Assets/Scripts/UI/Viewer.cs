using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Viewer : MonoBehaviour
{
    private TMP_Text view;

    private void Awake()
    {
        view = GetComponent<TMP_Text>();
    }

    public void SetView(int amount)
    {
        view.text = amount.ToString();
    }
}

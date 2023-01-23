using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthViewer : MonoBehaviour
{
    private TMP_Text healthView;

    private void Start()
    {
        healthView = GetComponent<TMP_Text>();
    }

    public void SetHealth(float health)
    {
        healthView.text = health.ToString();
    }
}

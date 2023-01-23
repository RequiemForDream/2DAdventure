using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    private Image healthBar;

    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    public void SetFillBar(float health)
    {       
       healthBar.fillAmount = (health / 100);        
    }
}

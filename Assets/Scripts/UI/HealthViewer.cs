using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class HealthViewer : MonoBehaviour
    {
        private TMP_Text view;

        private void Awake()
        {
            view = GetComponent<TMP_Text>();
        }

        public void SetView(float currentHealth, float maxHealth)
        {
            view.text = (currentHealth + "/" + maxHealth).ToString();
        }
    }
}
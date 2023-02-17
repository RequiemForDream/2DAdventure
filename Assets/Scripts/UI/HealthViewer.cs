using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class HealthViewer : MonoBehaviour
    {
        private TMP_Text view;

        private void Start()
        {
            view = GetComponent<TMP_Text>();
        }

        public void SetView(float amount)
        {
            view.text = amount.ToString();
        }
    }
}
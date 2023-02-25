using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ChooseShopPanel : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button gemShopButton;
        [SerializeField] private Button coinShopButton;
        [Space(10)]
        [SerializeField] private Button closeLastShopButton;
        [SerializeField] private Button closeMainPanel;

        [Header("Panels")]
        [SerializeField] private GameObject gemShopPanel;
        [SerializeField] private GameObject coinShopPanel;
        [Space(10)]
        [SerializeField] private GameObject mainPanel;

        private List<GameObject> panelJournal = new List<GameObject>();

        private void Start()
        {
            gemShopButton.onClick.AddListener(OpenGemShop);
            coinShopButton.onClick.AddListener(OpenCoinShop);
            closeLastShopButton.onClick.AddListener(CloseLastShop);
            closeMainPanel.onClick.AddListener(CloseMainPanel);
        }

        private void OpenGemShop()
        {
            gemShopPanel.SetActive(true);

            gemShopPanel.transform.SetAsLastSibling();

            panelJournal.Add(gemShopPanel);
        }

        private void OpenCoinShop()
        {
            coinShopPanel.SetActive(true);

            coinShopPanel.transform.SetAsLastSibling();

            panelJournal.Add(coinShopPanel);
        }

        private void CloseLastShop()
        {
            if (panelJournal.Count > 0)
            {
                var lastPanel = panelJournal.Last();

                lastPanel.SetActive(false);

                panelJournal.Remove(lastPanel);
            }
        }

        private void CloseMainPanel()
        {
            foreach (var obj in panelJournal)
            {
                obj.SetActive(false);
            }

            panelJournal.Clear();

            mainPanel.SetActive(false);
        }
    }
}
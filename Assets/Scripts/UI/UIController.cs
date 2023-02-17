using UnityEngine;
using Assets.Scripts.UI.CharacteristicsShop;

namespace Assets.Scripts.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CharacteristicsShop.CharacteristicsShop shop;

        private void Start()
        {
            shop.gameObject.SetActive(false);
        }

        private void Update()
        {
            CloseShop();
        }

        private void CloseShop()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (shop.gameObject.activeInHierarchy == true)
                {
                    shop.gameObject.SetActive(false);
                }
                else
                    shop.gameObject.SetActive(true);
            }
        }
    }
}
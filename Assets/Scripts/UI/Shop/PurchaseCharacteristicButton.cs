using Assets.Scripts.Character.Characteristics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.CharacteristicsShop
{
    public class PurchaseCharacteristicButton : MonoBehaviour, IPointerClickHandler
    {
        public delegate void OnTryToPuchase(GameObject sender, int price);
        public event OnTryToPuchase TryToPurchase;

        [SerializeField] private int price;
        [SerializeField] private int maxAmountOfPurchases = 10;        
        [SerializeField] private TMP_Text amountOfPurchasesText;
        [SerializeField] private TMP_Text priceText;

        [SerializeField] private CharacteristicChanger changer;

        private int currentAmountOfPurchases;

        private void Awake()
        {
            priceText.text = price.ToString();
            currentAmountOfPurchases = maxAmountOfPurchases;
            amountOfPurchasesText.text = (currentAmountOfPurchases + "/" + maxAmountOfPurchases).ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            TryToPurchase?.Invoke(this.gameObject, price);
        }

        public void OnCompletePurchase(GameObject sender)
        {
            currentAmountOfPurchases -= 1;
            amountOfPurchasesText.text = (currentAmountOfPurchases + "/" + maxAmountOfPurchases).ToString();
            changer.ChangeCharacteristic(); 
        }
    }
}
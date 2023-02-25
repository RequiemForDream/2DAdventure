using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public abstract class GemPurchaseWidget : MonoBehaviour
    {
        [Header("Purchase fields")]
        [SerializeField] protected int price;
        [SerializeField] protected string description;
        [Space(10)]
        [SerializeField] protected float changeAmount;
        [SerializeField] protected Sprite purchaseSprite;

        [Header("UI Components")]
        [SerializeField] protected TMP_Text priceAmountText;
        [SerializeField] protected Image purchaseImage;
        [Space(10)]
        [SerializeField] protected TMP_Text descriptionText;
        [SerializeField] protected TMP_Text changeAmountText;

        protected GemPurchaseWidget(int price, string description, float changeAmount, Sprite purchaseSprite)
        {
            this.price = price;
            this.description = description;
            this.changeAmount = changeAmount;
            this.purchaseSprite = purchaseSprite;
        }
        
        private void Awake()
        {
            SetImage();
            SetText();
        }

        private void SetText()
        {
            descriptionText.text = description;
            priceAmountText.text = price.ToString();
            changeAmountText.text = changeAmount.ToString();
        }

        private void SetImage()
        {
            purchaseImage.sprite = purchaseSprite;
        }
    }
}
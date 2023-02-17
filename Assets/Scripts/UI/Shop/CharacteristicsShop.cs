using Assets.Scripts.Mediator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.CharacteristicsShop
{
    public class CharacteristicsShop : MonoBehaviour
    {                     
        [SerializeField] private Transform shopPanel;
        [SerializeField] private ResourcesMediator resourcesMediator;
        [SerializeField] private Interactor _coinsInteractor;
        [SerializeField, GameObjectOfType(typeof(IValueHandler))] private GameObject valueHandler;

        private List<PurchaseCharacteristicButton> purchaseButtons;

        private int coinsAmount => valueHandler.GetComponent<IValueHandler>().value;

        private void Awake()
        {
            purchaseButtons = new List<PurchaseCharacteristicButton>();

            for (int i = 0; i < shopPanel.childCount; i++)
            {
                var button = shopPanel.GetChild(i).GetComponent<PurchaseCharacteristicButton>();
                purchaseButtons.Add(button);
            }  
        }

        private void OnEnable()
        {
            foreach (var button in purchaseButtons)
            {
                button.TryToPurchase += CheckMoney;
            }
        }

        private void OnDisable()
        {
            foreach (var button in purchaseButtons)
            {
                button.TryToPurchase -= CheckMoney;
            }
        }

        private void CheckMoney(GameObject sender, int price)
        {
            if (coinsAmount >= price)
            {
                resourcesMediator.coinsInteractor = _coinsInteractor;
                _coinsInteractor.Send(this.gameObject, -price);
                
                foreach (var button in purchaseButtons)
                {
                    if (button.gameObject == sender)
                    {
                        button.OnCompletePurchase(this.gameObject);
                    }
                }
            }                             
        }     
    }
}
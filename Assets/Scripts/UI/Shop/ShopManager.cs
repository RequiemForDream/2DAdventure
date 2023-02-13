﻿using Assets.Scripts.Mediator;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Shop
{
    public class ShopManager : MonoBehaviour
    {
        public delegate void OnPurchasedCompleted();
        public event OnPurchasedCompleted OnPurchaseCompleted;
        
        [SerializeField] private Transform shopPanel;
        [SerializeField] private ResourcesMediator resourcesMediator;
        [SerializeField] private Interactor _coinsInteractor;
        [SerializeField, GameObjectOfType(typeof(IValueHandler))] private GameObject valueHandler;

        private List<PurchaseButton> purchaseButtons;

        private int coinsAmount => valueHandler.GetComponent<IValueHandler>().value;

        private void Awake()
        {
            purchaseButtons = new List<PurchaseButton>();

            for (int i = 0; i < shopPanel.childCount; i++)
            {
                var button = shopPanel.GetChild(i).GetComponent<PurchaseButton>();
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
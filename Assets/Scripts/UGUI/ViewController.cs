using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

class ViewController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private HealthStorage healthStorage;
    [SerializeField]
    private Text healthText;

    [Header("Gold")]
    [SerializeField]
    private GoldStorage goldStorage;
    [SerializeField]
    private Text goldText;

    [Header("Picked")]
    [SerializeField]
    private PickManager pickManager;
    [SerializeField]
    private Text towerUpgradeCostText;

    private void Start()
    {
        healthStorage.PropertyChanged += PropertyChanged_UpdateView;
        goldStorage.PropertyChanged += PropertyChanged_UpdateView;
        pickManager.PropertyChanged += PickManager_PropertyChanged;

        UpdateView();
    }

    private void PickManager_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        UpdatePickView();
    }
    private void UpdatePickView()
    {
        if (pickManager.LastPick != null)
        {
            switch (pickManager.PickedObjectType.Name)
            {
                case nameof(UpgradeController):
                    towerUpgradeCostText.text = pickManager.GetComponent<UpgradeController>().UpgradeCost.ToString();
                    break;
            }

        }
    }
    private void UpdateView()
    {

        healthText.text = healthStorage.PlayerHp.ToString();
        goldText.text = goldStorage.Value.ToString();

    }

    private void PropertyChanged_UpdateView(object sender, PropertyChangedEventArgs e)
    {
        UpdateView();
    }
}
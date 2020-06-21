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

    private void Start()
    {
        healthStorage.PropertyChanged += PropertyChanged_UpdateView;
        goldStorage.PropertyChanged += PropertyChanged_UpdateView;

        UpdateView();
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
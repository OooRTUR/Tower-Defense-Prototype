using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    private ToolTipManager pickManager;
    [SerializeField]
    private Text toolTipViewText;

    [Header("Enemies destroyed")]
    [SerializeField]
    private EnemiesDestroyedCounter enemiesDestroyedCounter;
    [SerializeField]
    private Text enemiesDestroyedText;

    private IGameStatusHandler gameStatusHandler;

    [Header("Game state UI")]
    [SerializeField]
    private GameObject playStateUI;
    [SerializeField]
    private GameObject stopStateUI;

    private void Awake()
    {
        //gameStatusHandler = (IGameStatusHandler)FindInterfaces.Find<IGameStatusHandler>().First();
        //gameStatusHandler.GameStatusChanged += GameStatusHandler_GameStatusChanged;
    }
    private void Start()
    {


        //healthStorage.PropertyChanged += HealthStorage_UpdateView ;
        //goldStorage.PropertyChanged += GoldStorage_UpdateView;
        //enemiesDestroyedCounter.PropertyChanged += EnemiesDestroyedCounter_UpdateView;

        //pickManager.PropertyChanged += PickManager_UpdateView;

        //EnemiesDestroyedCounter_UpdateView(null, null);
        //GoldStorage_UpdateView(null, null);
        //HealthStorage_UpdateView(null, null);

        //PickManager_UpdateView(pickManager, null);

    }

    private void GameStatusHandler_GameStatusChanged(object sender, GameStatuChangedArgs e)
    {
        switch (e._GameStatus)
        {
            case GameStatus.GameOver:
                playStateUI.SetActive(false);
                stopStateUI.SetActive(true);
                break;
            case GameStatus.Play:
                playStateUI.SetActive(true);
                stopStateUI.SetActive(false);
                break;
        }
    }

    private void EnemiesDestroyedCounter_UpdateView(object sender, PropertyChangedEventArgs e)
    {
        enemiesDestroyedText.text = enemiesDestroyedCounter.Value.ToString();
    }

    private void GoldStorage_UpdateView(object sender, PropertyChangedEventArgs e)
    {
        goldText.text = goldStorage.Value.ToString();
    }

    private void HealthStorage_UpdateView(object sender, PropertyChangedEventArgs e)
    {
        healthText.text = healthStorage.PlayerHp.ToString();
    }

    //private void PickManager_UpdateView(object sender, PropertyChangedEventArgs e)
    //{
    //    var toolTipManager = ((ToolTipManager)sender);
    //    if (toolTipManager.ToolTipView != null) {
    //        toolTipViewText.text = toolTipManager.ToolTipView.GetView();
    //    }
    //    else
    //    {
    //        toolTipViewText.text = "";
    //    }
    //}
}
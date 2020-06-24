using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

class ViewController : MonoBehaviour
{

    private IGameStatusHandler gameStatusHandler;

    [Header("Game state UI")]
    [SerializeField]
    private GameObject playStateUI;
    [SerializeField]
    private GameObject stopStateUI;

    private void Awake()
    {

    }
    private void Start()
    {
        gameStatusHandler = (IGameStatusHandler)FindInterfaces.Find<IGameStatusHandler>().First();
        gameStatusHandler.GameStatusChanged += GameStatusHandler_GameStatusChanged;
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
}
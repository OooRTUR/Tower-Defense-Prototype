using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public enum GameStatus { Play, GameOver, None}
class GameManager : MonoBehaviour, IGameStatusHandler
{
    private GameStatus gameStatus = GameStatus.None;
    public GameStatus _GameStatus
    {
        private set
        {
            if (gameStatus != value)
            {
                gameStatus = value;
                GameStatusChanged?.Invoke(this, new GameStatuChangedArgs() { _GameStatus = gameStatus }) ;
            }
        }
        get { return gameStatus; }
    }

    public event EventHandler<GameStatuChangedArgs> GameStatusChanged;


    
    private void Start()
    {
        var healthStorage = (HealthStorage)FindObjectOfType(typeof(HealthStorage));
        healthStorage.healthZeroEvent.AddListener(GameOver);

        var wavesController = (WavesController)FindObjectOfType(typeof(WavesController));
        wavesController.LastWaveEvent.AddListener(GameOver);

        _GameStatus = GameStatus.Play;

    }

    private void GameOver()
    {
        _GameStatus = GameStatus.GameOver;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public GameStatus GetGameStatus()
    {
        return _GameStatus;
    }
}

public interface IGameStatusHandler
{
    event EventHandler<GameStatuChangedArgs> GameStatusChanged;
    GameStatus GetGameStatus();
}

public class GameStatuChangedArgs : EventArgs
{
    public GameStatus _GameStatus { set; get; }
}
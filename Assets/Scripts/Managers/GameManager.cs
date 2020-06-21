using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

class GameManager : MonoBehaviour
{

    public LevelConfiguration levelConfiguration;

    private void Start()
    {
        var healthStorage = (HealthStorage)FindObjectOfType(typeof(HealthStorage));
        healthStorage.healthZeroEvent.AddListener(StopGame);

        var wavesController = (WavesController)FindObjectOfType(typeof(WavesController));
        wavesController.LastWaveEvent.AddListener(StopGame);

    }

    private void StopGame()
    {
        Debug.Log("End of game");
        Debug.Break();
    }




}

using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

class GameManager : MonoBehaviour
{
    private SensitiveIntValue playerHp;
    private int playerGold;

    public LevelConfiguration levelConfiguration;


    private int currentWave;
    public int CurrentWave { get { return currentWave; } private set { currentWave = value; } }


    private void Awake()
    {

        playerHp = new SensitiveIntValue(CompareMode.LessThan, levelConfiguration.playerStartHP, 0);
        playerHp.Triggered.AddListener(StopGame);
        playerGold = levelConfiguration.playerStartGold;

        EventManager.StartListening("Bounty", delegate (object value)
        {
            playerGold += (int)value;
        });
        EventManager.StartListening("HomeTowerAttacked", delegate (object value)
        {
            playerHp.Value -= (int)value;
            Debug.Log("Player Hp: " + playerHp.Value);
        });

        EventManager.StartListening("NewTarget", AddNewTarget);
        EventManager.StartListening("NewTargetDestroyed", RemoveNewTarget);


        CurrentWave = 0;


    }



    private void StopGame()
    {
        Debug.Log("End of game");
        Debug.Break();
    }

    int wavesDestroyedCount;
    private void Start()
    {
        nextWaveTime = Time.deltaTime;


    }


    private float nextWaveTime;
    private void Update()
    {

        if (nextWaveTime < Time.time && CurrentWave < levelConfiguration.waves)
        {
            targetsCount = 0;
            EventManager.TriggerEvent("NewWave", CurrentWave);

            CurrentWave++;
            nextWaveTime = Time.time + levelConfiguration.timeBetweenWaves;
        }
    }

    private int targetsCount;
    private void AddNewTarget(object target)
    {
        targetsCount++;
        Debug.Log("targets count: " + targetsCount);
    }
    private void RemoveNewTarget(object target)
    {
        targetsCount--;
        Debug.Log("targets count: " + targetsCount);
        if(targetsCount == 0)
        {
            OnTargetsDestroyed();
        }
    }

    private void OnTargetsDestroyed()
    {
        if(CurrentWave == levelConfiguration.waves)
        {
            StopGame();
        }
    }
}

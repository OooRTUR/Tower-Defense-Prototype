using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WavesController : MonoBehaviour
{
    private int currentWave;
    public int CurrentWave { get { return currentWave; } private set { currentWave = value; } }

    public LevelConfiguration levelConfiguration;

    public UnityEvent LastWaveEvent;

    int wavesDestroyedCount;

    private void Awake()
    {


        LastWaveEvent = new UnityEvent();
    }

    private void Start()
    {
        EventManager.StartListening("NewTarget", AddNewTarget);
        EventManager.StartListening("NewTargetDestroyed", RemoveNewTarget);
        CurrentWave = 0;
        StartCoroutine(CallNewWave());
    }

    private IEnumerator CallNewWave()
    {
        nextWaveTime = Time.time + levelConfiguration.timeBetweenWaves;
        Debug.Log("next wave time: " + nextWaveTime);
        while (nextWaveTime >= Time.time)
        {
            yield return null;
        }
        targetsCount = 0;
        EventManager.TriggerEvent("NewWave", CurrentWave);
        CurrentWave++;
        //Debug.Log("new wave");
    }


    private float nextWaveTime;

    private int targetsCount;
    private void AddNewTarget(object target)
    {
        targetsCount++;
        //Debug.Log("targets count: " + targetsCount);
    }
    private void RemoveNewTarget(object target)
    {
        targetsCount--;
        //Debug.Log("targets count: " + targetsCount);
        if (targetsCount == 0)
        {
            OnTargetsDestroyed();
        }
    }

    private void OnTargetsDestroyed()
    {
        if (CurrentWave == levelConfiguration.waves)
        {
            LastWaveEvent?.Invoke();
        }
        else
        {
            StartCoroutine(CallNewWave());
        }
    }
}
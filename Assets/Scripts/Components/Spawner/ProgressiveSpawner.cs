using System;
using System.Collections;
using UnityEngine;

public class ProgressiveSpawner : BaseSpawner
{
    private int currentWaveGold = 0;
    private int currentWaveDamage = 0;

    [SerializeField]
    private int nextWaveDamageModifier = 1;
    [SerializeField]
    private int nextWaveGoldModifier = 5;
    [SerializeField]
    private int waveRandomAdd = 2;
    [SerializeField]
    private GameObject progressiveSpawnerNpcPrefab;
    [SerializeField]
    private float delayBetweenNPCSpawn = 0.2f;

    protected override GameObject SpawnNewNPC(GameObject prefab)
    {
        GameObject newNpc = base.SpawnNewNPC(prefab);
        BaseDamageTransmitter damageTransmitter = newNpc.GetComponent<BaseDamageTransmitter>();
        damageTransmitter.damage = currentWaveDamage;
        newNpc.GetComponent<Bounty>().value = currentWaveGold;
        return newNpc;

    }

    protected override void SpawnWave(object currentWaveIndex)
    {
        base.SpawnWave(currentWaveIndex);
        currentWaveGold += nextWaveGoldModifier;
        currentWaveDamage += nextWaveDamageModifier;

        StartCoroutine(SpawnNpcCoroutine());

    }

    private IEnumerator SpawnNpcCoroutine()
    {
        int currentWaveMaxCount = base.currentWaveIndex+1 + UnityEngine.Random.Range(0, waveRandomAdd);
        Debug.Log("currentWaveMaxCount: " +  currentWaveMaxCount);
        for(int i=0; i< currentWaveMaxCount; i++)
        {
            SpawnNewNPC(progressiveSpawnerNpcPrefab);
            yield return new WaitForSeconds(delayBetweenNPCSpawn);
        }
    }

    
}
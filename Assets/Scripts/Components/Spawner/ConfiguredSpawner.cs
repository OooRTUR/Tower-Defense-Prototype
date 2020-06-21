using UnityEngine;
using System.Collections;
using Boo.Lang;
using Unity.Entities.UniversalDelegates;
using Zenject.ReflectionBaking.Mono.Cecil;
using UnityEngine.Events;
using Zenject.SpaceFighter;

public class ConfiguredSpawner : BaseSpawner
{
    public WavesConfiguration waveConfig = new WavesConfiguration();
    protected override void SpawnWave(object currentWaveIndex)
    {
        base.SpawnWave(currentWaveIndex);
        WaveConfiguration currentWavePacks = waveConfig.waves[base.currentWaveIndex];
        foreach (var pack in currentWavePacks.packs)
        {
            StartCoroutine("SpawnPack", pack);
        }
    }

    private IEnumerator SpawnPack(PackConfiguration pack)
    {
        int maxValue = Random.Range(0, pack.addValue) + pack.minValue;
        for(int i=0; i <= maxValue; i++)
        {
            SpawnNewNPC(pack.NPC);
            yield return new WaitForSeconds(0.2f);
        }
    }

    
}

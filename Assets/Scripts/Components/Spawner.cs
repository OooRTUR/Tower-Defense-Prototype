using UnityEngine;
using System.Collections;
using Boo.Lang;
using Unity.Entities.UniversalDelegates;
using Zenject.ReflectionBaking.Mono.Cecil;

public class Spawner : MonoBehaviour
{
    public GameObject pathContainer;
    int counter = 0;


    public WavesConfiguration waveConfig = new WavesConfiguration();

    int currentWave = 0;

    public string targetName;

    private WaveConfiguration GetCurrentWave()
    {
        return waveConfig.waves[currentWave];
    }
    private void SpawnWave()
    {
        foreach(var pack in GetCurrentWave().packs)
        {
            StartCoroutine("SpawnPack", pack);
        }
        currentWave++;
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

    private void SpawnNewNPC(GameObject prefab)
    {
        GameObject newObj = GameObject.Instantiate(prefab);
        newObj.GetComponent<BaseDamageTransmitter>().Init(GameObject.Find(targetName), newObj.transform.position);
        newObj.name = $"NPC{counter}";
        newObj.GetComponent<PathFollowerBase>().Init(pathContainer);
        counter++;
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Spawn"))
        {
            SpawnWave();
        }
    }
}

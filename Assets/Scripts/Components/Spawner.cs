using UnityEngine;
using System.Collections;
using Boo.Lang;
using Unity.Entities.UniversalDelegates;
using Zenject.ReflectionBaking.Mono.Cecil;
using UnityEngine.Events;
using Zenject.SpaceFighter;

public class Spawner : MonoBehaviour
{
    public GameObject pathContainer;
    int counter = 0;

    public WavesConfiguration waveConfig = new WavesConfiguration();


    public string targetName;

    private void Start()
    {
        EventManager.StartListening("NewWave", SpawnWave);
    }
    private WaveConfiguration GetCurrentWavePacks(int currentWave)
    {
        return waveConfig.waves[currentWave];
    }
    private void SpawnWave(object currentWave)
    {
        Debug.Log("Spawning wave");
        
        foreach(var pack in GetCurrentWavePacks((int)currentWave).packs)
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

        }
    }
}

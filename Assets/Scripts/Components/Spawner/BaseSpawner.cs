using UnityEngine;
using System.Collections;

public class BaseSpawner : MonoBehaviour
{
    //init
    [SerializeField]
    protected GameObject pathContainer;
    [SerializeField]
    protected string targetName;

    //runtime
    protected int counter = 0;
    protected int currentWaveIndex;

    void Start()
    {
        EventManager.StartListening("NewWave", SpawnWave);
    }

    protected virtual void SpawnWave(object currentWaveIndex)
    {
        Debug.Log("Spawning wave");
        this.currentWaveIndex = (int)currentWaveIndex;
    }

    protected virtual GameObject SpawnNewNPC(GameObject prefab)
    {
        GameObject newObj = GameObject.Instantiate(prefab);
        newObj.transform.position = transform.position;
        newObj.name = $"NPC{counter}";
        counter++;
        newObj.GetComponent<PathFollowerBase>().Init(pathContainer);
        newObj.GetComponent<BaseDamageTransmitter>().Init(GameObject.Find(targetName), newObj.transform.position);
        return newObj;

    }
}

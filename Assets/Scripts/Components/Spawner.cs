using UnityEngine;
using System.Collections;
using Boo.Lang;
using Unity.Entities.UniversalDelegates;

public class Spawner : MonoBehaviour
{
    public GameObject pathContainer;
    int counter = 0;

    public LevelConfiguration levelConfig;

    public PackConfiguration wave1Config;
    public PackConfiguration wave2Config;
    public PackConfiguration wave3Config;

    private List<PackConfiguration> packConfiguration;

    public string targetName;

    private void Awake()
    {
        packConfiguration = new List<PackConfiguration>()
        {
            wave1Config,
            wave2Config,
            wave3Config
        };
    }

    private void Start()
    {
        
    }

    public void Spawn()
    {
        counter++;
  
    }

    private void SpawnWave()
    {
        foreach(var pack in packConfiguration)
        {
            for(var i =pack.npc1minValue; i <=pack.npc1addValue; i++)
            {

            }
        }
    }

    private void SpawnNewNPC(GameObject prefab)
    {
        GameObject newObj = GameObject.Instantiate(prefab);
        newObj.GetComponent<BaseDamageTransmitter>().Init(GameObject.Find(targetName), newObj.transform.position);
        newObj.name = $"NPC{counter}";
        newObj.GetComponent<PathFollowerBase>().Init(pathContainer);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Spawn"))
        {
            Spawn();
        }
    }
}

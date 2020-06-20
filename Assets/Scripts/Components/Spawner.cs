using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject nextPrefabToSpawn;
    public GameObject pathContainer;
    int counter = 0;

    public void Spawn()
    {
        counter++;
        GameObject newObj = GameObject.Instantiate(nextPrefabToSpawn);
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

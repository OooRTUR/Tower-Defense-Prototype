using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject nextPrefabToSpawn;
    public GameObject pathContainer;

    public void Spawn()
    {
        GameObject newObj = GameObject.Instantiate(nextPrefabToSpawn);
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

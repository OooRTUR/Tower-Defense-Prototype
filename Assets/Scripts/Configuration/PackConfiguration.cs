using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "PackConfiguration", menuName = "Configuration/PackConfiguration", order = 1)]
public class PackConfiguration : ScriptableObject
{
    public GameObject NPCPrefab;
    public int minValue;
    public int addVaue;
}
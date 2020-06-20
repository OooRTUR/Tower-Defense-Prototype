using UnityEngine;
using UnityEditor;
using Boo.Lang;
using System.Xml.Serialization;

[CreateAssetMenu(fileName = "LevelConfiguration", menuName = "Configuration/LevelConfiguration", order = 1)]
public class LevelConfiguration : ScriptableObject
{
    public float timeBetweenWaves;
}




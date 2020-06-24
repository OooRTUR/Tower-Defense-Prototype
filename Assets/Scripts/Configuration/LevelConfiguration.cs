using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfiguration", menuName = "Configuration/LevelConfiguration", order = 1)]
public class LevelConfiguration : ScriptableObject
{
    public float timeBetweenWaves;
    public int waves = 2;
    public int playerStartHP = 5;
    public int playerStartGold = 50;
}




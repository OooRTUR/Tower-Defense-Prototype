using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PackConfiguration
{
    [Header("NPC1")]
    public GameObject NPC;
    public int minValue;
    public int addValue;
}

[System.Serializable]
public class WaveConfiguration
{
    public List<PackConfiguration> packs;
}

[System.Serializable]
public class WavesConfiguration
{
    public List<WaveConfiguration> waves;
}
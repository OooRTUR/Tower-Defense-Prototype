using UnityEngine;
using UnityEditor;
using System.Collections;

[CreateAssetMenu(fileName = "PackConfiguration", menuName = "Configuration/PackConfiguration", order = 1)]
public class PackConfiguration : ScriptableObject
{
    [Header("NPC1")]
    public GameObject NPC1;
    public int npc1minValue;
    public int npc1addValue;

    [Header("NPC2")]
    public GameObject NPC2;
    public int npc2minValue;
    public int npc2addValue;

    [Header("NPC3")]
    public GameObject NPC3;
    public int npc3minValue;
    public int npc3addValue;
}
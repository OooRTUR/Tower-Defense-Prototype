using System.Collections.Generic;
using UnityEngine;

class GameManager : MonoBehaviour
{
    public int playerHP = 5;
    public int playerGold = 50;
    public LevelConfiguration levelConfiguration;
    

    private void Awake()
    {
        EventManager.StartListening("Bounty", delegate (object value)
        {
            playerGold += (int)value;
        });
        EventManager.StartListening("HomeTowerAttacked", delegate (object value)
        {
            playerHP -= (int)value;
        });
    }

    private void Update()
    {
        CheckEndGameConditions();
    }
    private void CheckEndGameConditions()
    {

    }
}

using System.Collections.Generic;
using UnityEngine;

class GameManager : SingletonObject<GameManager>
{
    public int playerHP = 5;
    public int playerGold = 50;
    

    private new void Awake()
    {
        base.Awake();
        EventManager.StartListening("Bounty", delegate (object value)
        {
            playerGold += (int)value;
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

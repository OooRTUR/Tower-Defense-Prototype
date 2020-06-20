using System.Collections.Generic;
using UnityEngine;

class GameManager : MonoBehaviour
{
    public int playerHP = 5;
    public int playerGold = 50;
    

    private void Awake()
    {
        EventManager.StartListening("Bounty", delegate (object value)
        {
            playerGold += (int)value;
        });
        EventManager.StartListening("HomeTowerAttacked", delegate (object value)
        {
            playerHP--;
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

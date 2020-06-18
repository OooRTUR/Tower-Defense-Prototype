using System.Collections.Generic;
using UnityEngine;

class GameManager : SingletonObject<GameManager>
{

    private new void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        CheckEndGameConditions();
    }
    private void CheckEndGameConditions()
    {

    }
}

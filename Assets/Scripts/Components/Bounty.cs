using System;
using UnityEngine;
class Bounty : MonoBehaviour
{

    public int value = 25;
    private GoldStorage goldStorage;

    private void Start()
    {
        goldStorage = GameObject.FindObjectOfType<GoldStorage>();
    }

    private void OnEnable()
    {
        //FindObjectOfType<GameManager>()
    }

    private bool bountyReleased = false;
    public void ReleaseBounty()
    {
        // this if branch made in test purpose
        if (!bountyReleased)
        {
            goldStorage.AddResource(value);
            bountyReleased = true;
        }
        else
        {
            throw new System.Exception($"{gameObject.name} tries to release Bounty signal one more time");
        }
    }

    private void OnDestroy()
    {
        ReleaseBounty();
    }
}
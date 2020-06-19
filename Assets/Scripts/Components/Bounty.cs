using System;
using UnityEngine;
class Bounty : MonoBehaviour
{

    public int value = 25;

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
            EventManager.TriggerEvent("Bounty", value);
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
using UnityEngine;
using System.Collections.Generic;

class TargetSearch : MonoBehaviour
{

    List<Target> foundTargets;

    private Target currentTarget;
    public Target CurrentTarget
    {
        private set 
        {
            if (currentTarget != null && value!=null)
            {
                if (currentTarget.GetInstanceID() != value.GetInstanceID())
                    currentTarget = value;
            }
            else
            {
                currentTarget = value;
            }
            OnTargetChanged();
        }
        get { return currentTarget; }
    }

    public ObjectArgEvent TargetFoundEvent;


    private void Awake()
    {
        foundTargets = new List<Target>();
        TargetFoundEvent = new ObjectArgEvent();
    }

    private void Update()
    {
        if (foundTargets.Count > 0)
        {
            CurrentTarget = foundTargets[0];
        }
        else
        {
            CurrentTarget = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var newTarget = other.GetComponent<Target>();
        if (newTarget == null) return;

        newTarget.TargetDestroyedEvent.AddListener(delegate
        {
            foundTargets.Remove(newTarget);
        });

        foundTargets.Add(newTarget);
    }

    private void OnTriggerExit(Collider other)
    {
        var newTarget = other.GetComponent<Target>();
        if (newTarget == null) return;

        foundTargets.Remove(newTarget);
        
    }

    public void OnTargetChanged()
    {
        GameObject targetArg = currentTarget == null ? null : currentTarget.gameObject;
        TargetFoundEvent?.Invoke(targetArg);
    }
}
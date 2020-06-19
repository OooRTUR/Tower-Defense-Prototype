using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

class TargetSearch : MonoBehaviour
{
    [SerializeField]
    string targetTagName;

    List<Transform> foundTargets;

    public Transform CurrentTarget { private set; get; }

    public ObjectArgEvent TargetFound;


    private void Awake()
    {
        foundTargets = new List<Transform>();
        TargetFound = new ObjectArgEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(targetTagName)) return;

        foundTargets.Add(other.transform);

        if (CurrentTarget == null)
            CurrentTarget = other.transform;
    }
    private void OnTriggerStay(Collider other)
    {
        if (CurrentTarget != null)
            OnTargetChanged();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTagName))
        {
            CurrentTarget = null;
            OnTargetChanged();
        }
        foundTargets.Remove(other.transform);
    }

    public void OnTargetChanged()
    {
        TargetFound?.Invoke(CurrentTarget);
    }
}
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
            OnTargetFound();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTagName))
            CurrentTarget = null;
        foundTargets.Remove(other.transform);
    }

    public void OnTargetFound()
    {
        TargetFound?.Invoke(CurrentTarget);
    }
}
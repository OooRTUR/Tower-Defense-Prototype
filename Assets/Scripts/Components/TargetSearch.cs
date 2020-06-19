using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

class TargetSearch : MonoBehaviour
{
    [SerializeField]
    string targetTagName;

    List<GameObject> foundTargets;

    public GameObject CurrentTarget { private set; get; }

    public ObjectArgEvent TargetFound;


    private void Awake()
    {
        foundTargets = new List<GameObject>();
        TargetFound = new ObjectArgEvent();
    }

    private void Update()
    {
        if (CurrentTarget.IsDestroyed())
        {
            foundTargets.Remove(CurrentTarget);
        }
        Debug.Log($"targetFound: {TargetFound}");
        if (foundTargets.Count > 0)
        {
            Debug.Log(foundTargets.Select(target => target.name).Aggregate((i, j) => i + "," + j));
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(targetTagName)) return;

        foundTargets.Add(other.gameObject);

        if (CurrentTarget == null)
            CurrentTarget = other.gameObject;
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
        foundTargets.Remove(other.gameObject);
    }

    public void OnTargetChanged()
    {
        TargetFound?.Invoke(CurrentTarget);
    }
}
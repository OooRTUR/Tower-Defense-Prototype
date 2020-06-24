using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    EnemiesDestroyedCounter counter;

    public UnityEvent TargetDestroyedEvent { private set; get; }
    public void Awake()
    {
        TargetDestroyedEvent = new UnityEvent();
        counter = (EnemiesDestroyedCounter)FindObjectOfType<EnemiesDestroyedCounter>();
    }

    private void OnEnable()
    {
        EventManager.TriggerEvent("NewTarget", gameObject);
    }

    private void OnDestroy()
    {
        TargetDestroyedEvent?.Invoke();
        EventManager.TriggerEvent("NewTargetDestroyed", gameObject);
        counter.AddResource(1);
    }
}

﻿using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent TargetDestroyedEvent { private set; get; }
    public void Awake()
    {
        TargetDestroyedEvent = new UnityEvent();
    }

    private void OnEnable()
    {
        EventManager.TriggerEvent("NewTarget", gameObject);
    }

    private void OnDestroy()
    {
        TargetDestroyedEvent?.Invoke();
        EventManager.TriggerEvent("NewTargetDestroyed", gameObject);
    }
}

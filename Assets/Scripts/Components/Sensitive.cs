using UnityEngine;
using System.Reflection;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

class Sensitive : MonoBehaviour
{
    ISensitiveValueContainer sensitiveValueContainer;

    private void Awake()
    {
        sensitiveValueContainer = transform.GetComponent<ISensitiveValueContainer>();
    }

    private void Update()
    {
        sensitiveValueContainer.CalculateSensitiveValues();
    }
}

public enum CompareMode { Less, LessThan, Equal, MoreThan, More}
[System.Serializable]
public class SensitiveFloatValue : BaseSensitiveValue
{
    public UnityEvent Triggered;
    private Func<float,float,bool> compareFunc;
    [SerializeField]
    private float triggerValue;
    [SerializeField]
    private float value;

    public float Value
    {
        set 
        { 
            this.value = value;
            if(compareFunc.Invoke(this.value, triggerValue))
            {
                Triggered?.Invoke();
            }
        }
        get { return value; }
    }
    

    public SensitiveFloatValue(CompareMode compareMode, float value, float triggerValue)
    {
        this.value = value;
        this.triggerValue = triggerValue;
        compareFunc = GetCompareFunc(compareMode);
        Triggered = new UnityEvent();
    }

    public override bool CheckForTrigger()
    {
        return compareFunc(value, triggerValue);
    }

    public Func<float,float,bool> GetCompareFunc(CompareMode compareMode)
    {
        Func<float,float,bool> compareFunc = null;
        switch (compareMode)
        {
            case CompareMode.Less:
                compareFunc = delegate (float value, float triggerValue)
                {
                    return value < triggerValue;
                };
                break;
            case CompareMode.LessThan:
                compareFunc = delegate(float value, float triggerValue)
                {
                    return value <= triggerValue;
                };
                break;
            case CompareMode.Equal:
                compareFunc = delegate (float value, float triggerValue)
                {
                    return value == triggerValue;
                };
                break;
            case CompareMode.More:
                compareFunc = delegate (float value, float triggerValue)
                {
                    return value >= triggerValue;
                };
                break;
            case CompareMode.MoreThan:
                compareFunc = delegate (float value, float triggerValue)
                {
                    return value > triggerValue;
                };
                break;
        }
        return compareFunc;
    }
}
public abstract class BaseSensitiveValue
{
    public abstract bool CheckForTrigger();
}

public interface ISensitiveValueContainer
{
    bool CalculateSensitiveValues();
    void OnSensitiveValuesTrigger();
}
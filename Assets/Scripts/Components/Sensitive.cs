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
        compareFunc = CompareFunc.GetCompareFloatFunc(compareMode);
        Triggered = new UnityEvent();
    }

    public override bool CheckForTrigger()
    {
        return compareFunc(value, triggerValue);
    }
}

public class SensitiveIntValue : BaseSensitiveValue
{
    private Func<int, int, bool> compareFunc;
    [SerializeField]
    private int triggerValue;
    [SerializeField]
    private int value;

    public int Value
    {
        set
        {
            this.value = value;
            if (compareFunc.Invoke(this.value, triggerValue))
            {
                Triggered?.Invoke();
            }
        }
        get { return value; }
    }


    public SensitiveIntValue(CompareMode compareMode, int value, int triggerValue)
    {
        this.value = value;
        this.triggerValue = triggerValue;
        compareFunc = CompareFunc.GetCompareIntFunc(compareMode);
        Triggered = new UnityEvent();
    }

    public override bool CheckForTrigger()
    {
        return compareFunc(value, triggerValue);
    }
}

public abstract class BaseSensitiveValue
{
    public UnityEvent Triggered;
    public abstract bool CheckForTrigger();
}

public interface ISensitiveValueContainer
{
    bool CalculateSensitiveValues();
    void OnSensitiveValuesTrigger();
}
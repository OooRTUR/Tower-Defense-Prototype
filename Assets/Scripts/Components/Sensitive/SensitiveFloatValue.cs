using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SensitiveFloatValue : BaseSensitiveValue
{

    private Func<float, float, bool> compareFunc;
    [SerializeField]
    private float triggerValue;
    [SerializeField]
    private float value;

    public float Value
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
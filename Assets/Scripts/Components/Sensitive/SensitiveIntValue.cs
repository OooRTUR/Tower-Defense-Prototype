using System;
using UnityEngine;
using UnityEngine.Events;

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

using System;
using UnityEngine;

public class GoldStorage : MonoBehaviour, IResourceStorage, IViewComponent
{



    [SerializeField]
    protected int value;

    public int Value
    {
        get { return value; }
        private set
        {
            if(this.value!= value)
            {
                this.value = value;
                ViewChanged?.Invoke(this, null);
            }
        }
    }

    //IResourceStorage impl.
    public void AddResource(int value)
    {
        this.Value += value;
    }
    public int GetResource(int value)
    {
        int res = 0;
        var subtraction = this.value - value;
        if (subtraction >= 0)
        {
            res = value;
            Value = subtraction;
        }
        return res;
    }

    //IViewComponent impl
    public event EventHandler ViewChanged;
    public object GetView()
    {
        return $"Gold: {Value}";
    }
}
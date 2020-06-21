using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GoldStorage : MonoBehaviour, IResourceStorage, INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;

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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }


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
}
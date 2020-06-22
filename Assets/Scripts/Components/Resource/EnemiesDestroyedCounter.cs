using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
class EnemiesDestroyedCounter : MonoBehaviour, IResourceStorage
{
    private int value;
    public int Value
    {
        get { return value; }
        private set
        {
            if (this.value != value)
            {
                this.value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void AddResource(int value)
    {
        this.Value += value;
    }

    public int GetResource(int value)
    {
        return 0;
    }
}
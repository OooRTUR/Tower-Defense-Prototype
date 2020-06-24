using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
class EnemiesDestroyedCounter : MonoBehaviour, IResourceStorage, IViewComponent
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
                ViewChanged?.Invoke(this, null);
            }
        }
    }

    public event EventHandler ViewChanged;

    public void AddResource(int value)
    {
        this.Value += value;
    }

    public int GetResource(int value)
    {
        return 0;
    }

    public object GetView()
    {
        return "Enemies Destroyed: " + Value;
    }
}
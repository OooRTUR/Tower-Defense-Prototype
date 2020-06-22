using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
class EnemiesDestroyedCounter : MonoBehaviour, IResourceStorage
{
    private int value;
    //public int Value
    //{
    //    get { return value; }
    //    private set
    //    {
    //        if (this.value != value)
    //        {
    //            this.value = value;
    //            Debug.Log("Enemies destroyed: " + this.value);
    //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
    //        }
    //    }
    //}

    //public event PropertyChangedEventHandler PropertyChanged;

    public void AddResource(int value)
    {
        this.value += value;
    }

    public int GetResource(int value)
    {
        return 0;
    }
}
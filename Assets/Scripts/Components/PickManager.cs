using UnityEngine;
using System.Collections;
using System.ComponentModel;
using System;

public class PickManager : MonoBehaviour, INotifyPropertyChanged
{
    private GameObject lastPick;
    public GameObject LastPick
    {
        private set 
        {
            if (lastPick != value)
            {
                lastPick = value;
                PickedObjectType = value.GetComponent<IPickableComponent>().GetPickableType();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastPick"));
            }
        }
        get { return lastPick; }
    }

    public Type PickedObjectType { get; private set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public void PickObject(GameObject picked)
    {
        LastPick = picked;
    }
    public void UnPickObject(GameObject picked)
    {
        if (lastPick.GetInstanceID() == picked.GetInstanceID())
        {
            LastPick = null;
        }
    }

}

public interface IPickableComponent
{
    Type GetPickableType();
}

using System;
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

    

    //IResourceStorage impl.
    public void AddResource(int value)
    {
        this.Value += value;
    }

    public int GetResource(int value)
    {
        return 0;
    }

    //IViewComponent impl.
    public event EventHandler ViewChanged;
    public object GetView()
    {
        return "Enemies Destroyed: " + Value;
    }
}
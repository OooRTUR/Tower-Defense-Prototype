using UnityEngine;
using System.Collections;
using System.ComponentModel;
using System;

public class ToolTipManager : MonoBehaviour, INotifyPropertyChanged
{
    private ToolTipShowComponent toolTipView;
    public ToolTipShowComponent ToolTipView
    {
        get { return toolTipView; }
        private set
        {
            if(toolTipView!= value)
            {
                toolTipView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ToolTipView"));
            }
        }
    }
    private GameObject lastPick;

    public event PropertyChangedEventHandler PropertyChanged;

    public void PickObject(GameObject picked, ToolTipShowComponent toolTipView)
    {
        ToolTipView = toolTipView;
        lastPick = picked;
    }
    public void UnPickObject(GameObject picked)
    {
        if (lastPick.GetInstanceID() == picked.GetInstanceID())
        {
            lastPick = null;
            ToolTipView = null;
        }
    }

}

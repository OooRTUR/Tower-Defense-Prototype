using UnityEngine;
using System.Collections;
using System.ComponentModel;
using System;

public class ToolTipManager : MonoBehaviour, IViewComponent
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
            }
        }
    }
    private GameObject lastPick;
    public event EventHandler ViewChanged;

    private void Awake()
    {
        
    }

    public void PickObject(GameObject picked, ToolTipShowComponent toolTipView)
    {
        ToolTipView = toolTipView;
        lastPick = picked;
        ViewChanged?.Invoke(this, null);
    }



    public void UnPickObject(GameObject picked)
    {
        if (lastPick.GetInstanceID() == picked.GetInstanceID())
        {
            lastPick = null;
            ToolTipView = null;
            ViewChanged?.Invoke(this, null);
        }
    }

    public object GetView()
    {
        if (lastPick != null)
            return lastPick.GetComponent<IViewComponent>().GetView();
        else
            return "";
    }
}

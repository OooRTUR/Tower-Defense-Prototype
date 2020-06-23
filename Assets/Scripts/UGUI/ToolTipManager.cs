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
    private IViewComponent viewComponent;

    public event EventHandler ViewChanged;

    public void PickObject(GameObject picked, ToolTipShowComponent toolTipView)
    {
        ToolTipView = toolTipView;
        lastPick = picked;
        viewComponent = lastPick.GetComponent<IViewComponent>();
        viewComponent.ViewChanged += ToolTipManager_ViewChanged;
    }

    private void ToolTipManager_ViewChanged(object sender, EventArgs e)
    {
        ViewChanged?.Invoke(sender, null);
    }

    public void UnPickObject(GameObject picked)
    {
        if (lastPick.GetInstanceID() == picked.GetInstanceID())
        {
            lastPick = null;
            ToolTipView = null;
            viewComponent.ViewChanged.
        }
    }

    public object GetView()
    {
        return viewComponent.GetView();
    }
}

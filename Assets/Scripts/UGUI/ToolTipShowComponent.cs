using System;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipShowComponent : MonoBehaviour
{
    private ToolTipManager toolTipManager;
    [SerializeField]
    protected GameObject toolTipObject;

    private void Awake()
    {
        toolTipManager = GameObject.FindObjectOfType<ToolTipManager>();
    }

    //private void OnMouseEnter()
    //{
    //    toolTipManager.PickObject(toolTipObject,this);
    //}

    private void OnMouseOver()
    {
        toolTipManager.PickObject(toolTipObject, this);
    }

    private void OnMouseExit()
    {
        toolTipManager.UnPickObject(toolTipObject);
    }
}
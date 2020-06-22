using System;
using System.Collections.Generic;
public class UpgradeControllerToolTipShow : ToolTipShowComponent
{
    public override string GetView()
    {
        return $"{base.toolTipObject.name} UpgradeCost: "  +  base.toolTipObject.GetComponent<UpgradeController>().UpgradeCost.ToString();
    }
}